using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Actor
{
    public abstract class BaseMovableActor : BaseActor
    {
        /// <summary>
        /// Represents speed multiplier.
        /// </summary>
        public abstract float Acceleration
        {
            get;
        }

        /// <summary>
        /// Represents maximum object's speed.
        /// </summary>
        public abstract float MaxSpeed
        {
            get;
        }

        /// <summary>
        /// Represents object's rotation speed.
        /// </summary>
        public abstract float RotationSpeed
        {
            get;
        }

        /// <summary>
        /// Method which used to move object to position on game field.
        /// </summary>
        /// <param name="destination">Move destination.</param>
        public abstract void MoveTo(Vector3 destination);

        /// <summary>
        /// Method which used to rotate object forward to position on game field.
        /// </summary>
        /// <param name="destination">Position to rotate.</param>
        public abstract void RotateTo(Vector3 destination);
    }
}
