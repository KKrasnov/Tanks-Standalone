using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor.Bullet;

namespace TanksTest.Core.Actor.Modules.Cannon
{
    public class Cannon : MonoBehaviour, ICannon
    {
        [SerializeField]
        private GameObject _bulletPrefab;

        public GameObject BulletPrefab
        {
            get
            {
                return _bulletPrefab;
            }
        }

        public float ReloadingDuration
        {
            get;
            private set;
        }

        [SerializeField]
        private float _maxReloadingDuration = 1f;

        public float MaxReloadingDuration
        {
            get
            {
                return _maxReloadingDuration;
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

        [SerializeField]
        private Transform _bulletSpawnPoint;

        public event Action<IActor> OnDisposeEvent;

        private void Update()
        {
            DoReloading();
        }

        private void DoReloading()
        {
            if (ReloadingDuration > 0)
                ReloadingDuration -= Time.deltaTime;
            else if (ReloadingDuration < 0)
                ReloadingDuration = 0;
        }

        private void Reload()
        {
            ReloadingDuration = _maxReloadingDuration;
        }

        public void Fire(Vector3 direction)
        {
            if (ReloadingDuration != 0) return;
            GameObject bulletObj = GameObject.Instantiate(_bulletPrefab);
            IBullet bullet = bulletObj.GetComponent<IBullet>();
            bullet.Position = _bulletSpawnPoint.position;
            bullet.RotateTo(direction);
            bullet.MoveTo(direction);
            Reload();
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
