using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor.Bullet;

namespace TanksTest.Core.Actor.Modules.Cannon
{
    public interface ICannon : IActor
    {
        GameObject BulletPrefab
        {
            get;
        }

        float ReloadingDuration
        {
            get;
        }

        float MaxReloadingDuration
        {
            get;
        }

        void Fire(Vector3 direction);
    }
}
