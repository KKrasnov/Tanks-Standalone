using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor.Bullet;
using TanksTest.Core.Actor.Modules.Cannon;

namespace TanksTest.Core.Actor.Tank
{
    public class Tank : MonoBehaviour, ITank
    {
        [SerializeField]
        private Transform _turret;

        [SerializeField]
        private List<GameObject> _cannonObjects;

        [SerializeField]
        private Rigidbody _rigidbody;

        private ICannon _currentCannon;

        public ICannon CurrentCannon
        {
            get
            {
                return _currentCannon;
            }
            private set
            {
                _currentCannon.SetActive(false);
                _currentCannon = value;
                _currentCannon.SetActive(true);
            }
        }

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

        [SerializeField]
        private float _turretRotationSpeed = 15f;

        public float TurretRotationSpeed
        {
            get
            {
                return _turretRotationSpeed;
            }
        }

        private LinkedList<ICannon> _cannons = new LinkedList<ICannon>();

        private Vector3 _moveDirection;
        private Vector3 _worldTurretDestination;

        public event Action<IActor> OnDisposeEvent;
        public event Action<int> OnDamageTakenEvent;
        public event Action<int> OnHealTakenEvent;


        private void Awake()
        {
            foreach (var obj in _cannonObjects)
            {
                ICannon cannon = obj.GetComponent<ICannon>();
                _cannons.AddLast(cannon);
                cannon.SetActive(false);
            }
            _currentCannon = _cannons.First.Value;
            _currentCannon.SetActive(true);
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

        public void MoveTo(Vector3 destination)
        {
            _moveDirection = destination;
        }

        public void RotateTo(Vector3 destination)
        {
            if (_moveDirection.normalized == -transform.forward)
                destination = -destination;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(destination), Time.deltaTime * _rotationSpeed);
        }

        public void RotateTurretTo(Vector3 destination)
        {
            _worldTurretDestination = (new Vector3(destination.x, _turret.position.y, destination.z) - _turret.position).normalized;
        }

        public void DoDamage(float damageAmount)
        {
            CurrentHealthPoints -= (int)(Mathf.Abs(damageAmount) * _damageMultiplier);
        }

        public void DoHeal(float healAmount)
        {
            CurrentHealthPoints += (int)Mathf.Abs(healAmount);
        }

        public void Shoot()
        {
            _currentCannon.Fire(_turret.forward);
        }

        public void ApplyNextCannon()
        {
            var node = _cannons.Find(_currentCannon);
            if (node.Next == null)
                CurrentCannon = _cannons.First.Value;
            else
                CurrentCannon = node.Next.Value;
        }

        public void ApplyPrevCannon()
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

        public void Dispose()
        {

        }
    }
}
