using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Actor.Tank
{
    public interface ITank : IMovableActor, IDamagable, IDamager, IShooter
    {
        float TurretRotationSpeed
        {
            get;
        }

        void RotateTurretTo(Vector3 destination);

        void ApplyNextCannon();
        void ApplyPrevCannon();
    }
}
