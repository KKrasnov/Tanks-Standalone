using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor.Modules.Cannon;

namespace TanksTest.Core.Actor.Tank
{
    public abstract class BaseTank : BaseMovableActor, IDamagable, IDamager, IShooter
    {
        public abstract float TurretRotationSpeed
        {
            get;
        }

        public abstract BaseCannon CurrentCannon
        {
            get;
            protected set;
        }

        public abstract float DamagePower
        {
            get;
        }

        public abstract int CurrentHealthPoints
        {
            get;
            protected set;
        }

        public abstract int MaxHealthPoints
        {
            get;
        }

        public abstract float DamageMultiplier
        {
            get;
        }

        public abstract void DoDamage(float damageAmount);

        public abstract void DoHeal(float healAmount);

        public abstract event Action<int> OnDamageTakenEvent;
        public abstract event Action<int> OnHealTakenEvent;

        public abstract void RotateTurretTo(Vector3 destination);

        public abstract void ApplyNextCannon();
        public abstract void ApplyPrevCannon();

        public abstract void Shoot();
    }
}
