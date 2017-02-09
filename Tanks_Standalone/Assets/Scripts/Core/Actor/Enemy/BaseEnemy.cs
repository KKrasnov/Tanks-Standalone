using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Actor.Enemy
{
    public abstract class BaseEnemy : BaseMovableActor, IDamagable, IDamager
    {
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

        public abstract float DamagePower
        {
            get;
        }

        public abstract void DoDamage(float damageAmount);

        public abstract void DoHeal(float healAmount);

        public abstract event Action<int> OnDamageTakenEvent;
        public abstract event Action<int> OnHealTakenEvent;
    }
}