using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Actor
{
    public interface IDamagable
    {
        /// <summary>
        /// Represents current object health points.
        /// </summary>
        int CurrentHealthPoints
        {
            get;
        }

        /// <summary>
        /// Represents maximum health points that object able to earn.
        /// </summary>
        int MaxHealthPoints
        {
            get;
        }

        /// <summary>
        /// Represents defense power of object.
        /// </summary>
        float DamageMultiplier
        {
            get;
        }

        /// <summary>
        /// Methods which used to deal damage to object, include defense power.
        /// </summary>
        /// <param name="damageAmount">Clear damage amount.</param>
        void DoDamage(float damageAmount);

        /// <summary>
        /// Methods which used to heal object, exclude defense power.
        /// </summary>
        /// <param name="damageAmount">Clear heal amount.</param>
        void DoHeal(float healAmount);

        event Action<int> OnDamageTakenEvent;
        event Action<int> OnHealTakenEvent;
    }
}
