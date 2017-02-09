using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Actor.Enemy
{
    public class Enemy : BaseEnemy
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        [SerializeField]
        private float _damagePower;

        public override float DamagePower
        {
            get
            {
                return _damagePower;
            }
        }

        private int _currentHealthPoints = 0;

        public override int CurrentHealthPoints
        {
            get
            {
                return _currentHealthPoints;
            }
            protected set
            {
                Debug.LogWarning(_currentHealthPoints + " " + value);
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
                if (_currentHealthPoints <= 0)
                    GameObject.Destroy(this.gameObject);
            }
        }

        [SerializeField]
        private int _maxHealthPoints = 100;

        public override int MaxHealthPoints
        {
            get
            {
                return _maxHealthPoints;
            }
        }

        [SerializeField]
        private float _damageMultiplier = 0.5f;

        public override float DamageMultiplier
        {
            get
            {
                return _damageMultiplier;
            }
        }

        [SerializeField]
        private float _acceleration = 15f;

        public override float Acceleration
        {
            get
            {
                return _acceleration;
            }
        }

        [SerializeField]
        private float _maxSpeed = 15f;

        public override float MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
        }

        [SerializeField]
        private float _rotationSpeed = 15f;

        public override float RotationSpeed
        {
            get
            {
                return _rotationSpeed;
            }
        }

        private Vector3 _moveDirection = Vector3.zero;

        [SerializeField]
        private string _targetTag = "player";

        public override event Action<BaseActor> OnDisposeEvent;
        public override event Action<int> OnDamageTakenEvent;
        public override event Action<int> OnHealTakenEvent;

        private void Start()
        {
            CurrentHealthPoints = _maxHealthPoints;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (_moveDirection == Vector3.zero) return;

            if (Vector3.Dot(_moveDirection, _rigidbody.velocity.normalized) > 0)
            {
                Vector3 newVelocity = _moveDirection * _rigidbody.velocity.magnitude;
                _rigidbody.velocity = newVelocity;
            }

            _rigidbody.AddForce(_moveDirection * _acceleration);

            if (_rigidbody.velocity.magnitude > _maxSpeed)
                _rigidbody.velocity = _rigidbody.velocity.normalized * _maxSpeed;

            _moveDirection = Vector3.zero;
        }

        public override void MoveTo(Vector3 destination)
        {
            _moveDirection = destination;
        }

        public override void RotateTo(Vector3 destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            _rigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(destinationDirection), Time.deltaTime * _rotationSpeed));
        }

        public override void DoDamage(float damageAmount)
        {
            CurrentHealthPoints -= Mathf.RoundToInt(Mathf.Abs(damageAmount) * _damageMultiplier);
        }

        public override void DoHeal(float healAmount)
        {
            CurrentHealthPoints +=  Mathf.RoundToInt(Mathf.Abs(healAmount));
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == _targetTag)
            {
                IDamagable _targetActor = other.gameObject.GetComponent<IDamagable>();
                _targetActor.DoDamage(_damagePower);
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
            if (OnDisposeEvent != null)
                OnDisposeEvent(this);
        }
    }
}
