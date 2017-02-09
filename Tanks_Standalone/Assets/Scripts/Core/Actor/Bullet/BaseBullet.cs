using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Actor.Bullet
{
    public abstract class BaseBullet : BaseMovableActor, IDamager
    {
        public abstract float DamagePower
        {
            get;
        }
    }
}
