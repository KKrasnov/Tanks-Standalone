using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor.Bullet;
using TanksTest.Core.Actor.Modules.Cannon;

namespace TanksTest.Core.Actor
{
    public interface IShooter
    {
        ICannon CurrentCannon
        {
            get;
        }

        void Shoot();
    }
}
