using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Actor.Bullet
{
    public class Bullet : BaseBullet
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        [SerializeField]
        private string _targetTag;

        [SerializeField]
        private float _damagePower = 10f;

        public override float DamagePower
        {
            get
            {
                return _damagePower;
            }
        }

        public override float Acceleration
        {
            get;
        }

        [SerializeField]
        private float _maxSpeed = 30f;

        public override float MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
        }

        private float _rotationSpeed = 0f;

        public override float RotationSpeed
        {
            get
            {
                return _rotationSpeed;
            }
        }

        private Vector3 _moveDirection;

        public override event Action<BaseActor> OnDisposeEvent;

        private void Awake()
        {
            StartCoroutine(DestroyAfterTime(10f));
        }

        private void FixedUpdate()
        {
            Move();
        }

        private IEnumerator DestroyAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
            GameObject.Destroy(this.gameObject);
        }

        private void Move()
        {
            if (_moveDirection == Vector3.zero) return;
            _rigidbody.velocity = _moveDirection * _maxSpeed;
            _moveDirection = Vector3.zero;
        }

        public override void MoveTo(Vector3 destination)
        {
            _moveDirection = destination;
        }

        public override void RotateTo(Vector3 destination)
        {
            Quaternion lookRotation = Quaternion.LookRotation(destination);
            transform.rotation = lookRotation;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == _targetTag)
            {
                IDamagable targetActor = other.gameObject.GetComponent<IDamagable>();
                targetActor.DoDamage(this._damagePower);
            }
            GameObject.Destroy(this.gameObject);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
            if (OnDisposeEvent != null)
                OnDisposeEvent(this);
        }
    }
}
