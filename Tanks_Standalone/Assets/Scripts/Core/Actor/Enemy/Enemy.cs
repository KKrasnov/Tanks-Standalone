using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Actor.Enemy
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        public string Name
        {
            get
            {
                return gameObject.name;
            }
        }

        public Vector3 Position
        {
            get
            {
                return transform.position;
            }
            set
            {
                transform.position = value;
            }
        }

        public Vector3 Forward
        {
            get
            {
                return transform.forward;
            }
        }

        public Vector3 Right
        {
            get
            {
                return transform.right;
            }
        }

        public Vector3 Rotation
        {
            get
            {
                return transform.eulerAngles;
            }
            set
            {
                transform.eulerAngles = value;
            }
        }

        private float _damagePower = 10000f;

        public float DamagePower
        {
            get
            {
                return _damagePower;
            }
        }

        private int _currentHealthPoints = 0;

        public int CurrentHealthPoints
        {
            get
            {
                return _currentHealthPoints;
            }
            private set
            {
                int prevHP = _currentHealthPoints;
                _currentHealthPoints = value;
                if (_currentHealthPoints > prevHP)
                {
                    if (OnHealTakenEvent != null)
                        OnHealTakenEvent(_currentHealthPoints - prevHP);
                }
                else if (_currentHealthPoints < prevHP)
                {
                    if (OnDamageTakenEvent != null)
                        OnDamageTakenEvent(prevHP - _currentHealthPoints);
                }

            }
        }

        [SerializeField]
        private int _maxHealthPoints = 100;

        public int MaxHealthPoints
        {
            get
            {
                return _maxHealthPoints;
            }
        }

        [SerializeField]
        private float _damageMultiplier = 0.5f;

        public float DamageMultiplier
        {
            get
            {
                return _damageMultiplier;
            }
        }

        [SerializeField]
        private float _acceleration = 15f;

        public float Acceleration
        {
            get
            {
                return _acceleration;
            }
        }

        [SerializeField]
        private float _maxSpeed = 15f;

        public float MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
        }

        [SerializeField]
        private float _rotationSpeed = 15f;

        public float RotationSpeed
        {
            get
            {
                return _rotationSpeed;
            }
        }

        public event Action<IActor> OnDisposeEvent;
        public event Action<int> OnDamageTakenEvent;
        public event Action<int> OnHealTakenEvent;

        public void MoveTo(Vector3 destination)
        {
        }

        public void RotateTo(Vector3 destination)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(destination), Time.deltaTime * _rotationSpeed);
        }

        public void DoDamage(float damageAmount)
        {
            CurrentHealthPoints -= (int)(Mathf.Abs(damageAmount) * _damageMultiplier);
        }

        public void DoHeal(float healAmount)
        {
            CurrentHealthPoints += (int)Mathf.Abs(healAmount);
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void Dispose()
        {

        }
    }
}
