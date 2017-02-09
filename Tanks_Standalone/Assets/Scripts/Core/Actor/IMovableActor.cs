using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Actor
{
    public interface IMovableActor : IActor
    {
        /// <summary>
        /// Represents speed multiplier.
        /// </summary>
        float Acceleration
        {
            get;
        }

        /// <summary>
        /// Represents maximum object's speed.
        /// </summary>
        float MaxSpeed
        {
            get;
        }

        /// <summary>
        /// Represents object's rotation speed.
        /// </summary>
        float RotationSpeed
        {
            get;
        }

        /// <summary>
        /// Method which used to move object to position on game field.
        /// </summary>
        /// <param name="destination">Move destination.</param>
        void MoveTo(Vector3 destination);

        /// <summary>
        /// Method which used to rotate object forward to position on game field.
        /// </summary>
        /// <param name="destination">Position to rotate.</param>
        void RotateTo(Vector3 destination);
    }
}
