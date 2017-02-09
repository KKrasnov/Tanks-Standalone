using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor.Bullet;

namespace TanksTest.Core.Actor.Modules.Cannon
{
    public abstract class BaseCannon : BaseActor
    {
        public abstract GameObject BulletPrefab
        {
            get;
        }

        public abstract float ReloadingDuration
        {
            get;
            protected set;
        }

        public abstract float MaxReloadingDuration
        {
            get;
        }

        public abstract void Fire(Vector3 direction);
    }
}
