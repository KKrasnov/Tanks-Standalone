using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor.Bullet;
using TanksTest.Core.Actor.Modules.Cannon;

namespace TanksTest.Core.Actor.Tank
{
    public class Tank : BaseTank
    {
        [SerializeField]
        private Transform _turret;

        [SerializeField]
        private Rigidbody _rigidbody;

        [SerializeField]
        private List<BaseCannon> _cannonList;

        private BaseCannon _currentCannon;

        public override BaseCannon CurrentCannon
        {
            get
            {
                return _currentCannon;
            }
            protected set
            {
                _currentCannon.gameObject.SetActive(false);
                _currentCannon = value;
                _currentCannon.gameObject.SetActive(true);
            }
        }

        private float _damagePower = 10000f;

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

        [SerializeField]
        private float _turretRotationSpeed = 15f;

        public override float TurretRotationSpeed
        {
            get
            {
                return _turretRotationSpeed;
            }
        }

        [SerializeField]
        private string _targetTag = "enemy";

        [SerializeField]
        private LinkedList<BaseCannon> _cannons = new LinkedList<BaseCannon>();

        private Vector3 _moveDirection;
        private Vector3 _worldTurretDestination;

        public override event Action<BaseActor> OnDisposeEvent;
        public override event Action<int> OnDamageTakenEvent;
        public override event Action<int> OnHealTakenEvent;


        private void Awake()
        {
            _cannons = new LinkedList<BaseCannon>(_cannonList);
            _currentCannon = _cannons.First.Value;
            _currentCannon.gameObject.SetActive(true);
        }

        private void Start()
        {
            CurrentHealthPoints = _maxHealthPoints;
        }

        private void Update()
        {
            RotateTurret();
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

        private void RotateTurret()
        {
            _turret.rotation = Quaternion.RotateTowards(_turret.rotation, Quaternion.LookRotation(_worldTurretDestination), Time.deltaTime * _turretRotationSpeed);
            _turret.eulerAngles = new Vector3(0, _turret.eulerAngles.y, 0);
        }

        public override void MoveTo(Vector3 destination)
        {
            _moveDirection = destination;
        }

        public override void RotateTo(Vector3 destination)
        {
            if (_moveDirection.normalized == -transform.forward)
                destination = -destination;

            _rigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(destination), Time.deltaTime * _rotationSpeed));
        }

        public override void RotateTurretTo(Vector3 destination)
        {
            _worldTurretDestination = (new Vector3(destination.x, _turret.position.y, destination.z) - _turret.position).normalized;
        }

        public override void DoDamage(float damageAmount)
        {
            CurrentHealthPoints -= Mathf.RoundToInt(Mathf.Abs(damageAmount) * _damageMultiplier);
        }

        public override void DoHeal(float healAmount)
        {
            CurrentHealthPoints += Mathf.RoundToInt(Mathf.Abs(healAmount));
        }

        public override void Shoot()
        {
            _currentCannon.Fire(_turret.forward);
        }

        public override void ApplyNextCannon()
        {
            var node = _cannons.Find(_currentCannon);
            if (node.Next == null)
                CurrentCannon = _cannons.First.Value;
            else
                CurrentCannon = node.Next.Value;
        }

        public override void ApplyPrevCannon()
        {
            var node = _cannons.Find(_currentCannon);
            if (node.Previous == null)
                CurrentCannon = _cannons.Last.Value;
            else
                CurrentCannon = node.Previous.Value;
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
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
