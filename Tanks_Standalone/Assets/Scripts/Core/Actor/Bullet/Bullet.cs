using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Actor.Bullet
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField]
        private Rigidbody _rigidbody;

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

        [SerializeField]
        private float _damagePower = 10f;

        public float DamagePower
        {
            get
            {
                return _damagePower;
            }
        }

        [SerializeField]
        private float _acceleration = 10f;

        public float Acceleration
        {
            get
            {
                return _acceleration;
            }
        }

        [SerializeField]
        private float _maxSpeed = 30f;

        public float MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
        }

        private float _rotationSpeed = 0f;

        public float RotationSpeed
        {
            get
            {
                return _rotationSpeed;
            }
        }

        private Vector3 _moveDirection;

        public event Action<IActor> OnDisposeEvent;

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _rigidbody.AddForce(_moveDirection * _acceleration);

            if (_rigidbody.velocity.magnitude > _maxSpeed)
                _rigidbody.velocity = _rigidbody.velocity.normalized * _maxSpeed;
        }

        public void MoveTo(Vector3 destination)
        {
            _moveDirection = destination;
        }

        public void RotateTo(Vector3 destination)
        {
            Quaternion lookRotation = Quaternion.LookRotation(destination);
            transform.rotation = lookRotation;
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
