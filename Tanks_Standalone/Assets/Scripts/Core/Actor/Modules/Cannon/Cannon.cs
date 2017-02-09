using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor.Bullet;

namespace TanksTest.Core.Actor.Modules.Cannon
{
    public class Cannon : BaseCannon
    {
        [SerializeField]
        private GameObject _bulletPrefab;

        public override GameObject BulletPrefab
        {
            get
            {
                return _bulletPrefab;
            }
        }

        public override float ReloadingDuration
        {
            get;
            protected set;
        }

        [SerializeField]
        private float _maxReloadingDuration = 1f;

        public override float MaxReloadingDuration
        {
            get
            {
                return _maxReloadingDuration;
            }
        }

        [SerializeField]
        private Transform _bulletSpawnPoint;

        public override event Action<BaseActor> OnDisposeEvent;

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

        public override void Fire(Vector3 direction)
        {
            if (ReloadingDuration != 0) return;
            GameObject bulletObj = GameObject.Instantiate(_bulletPrefab);
            BaseBullet bullet = bulletObj.GetComponent<BaseBullet>();
            bullet.transform.position = _bulletSpawnPoint.position;
            bullet.RotateTo(direction);
            bullet.MoveTo(direction);
            Reload();
        }
    }
}
