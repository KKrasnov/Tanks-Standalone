using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Actor
{
    public interface IActor : IDisposable
    {
        /// <summary>
        /// Represents object's name.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Represents object's position on game field.
        /// </summary>
        Vector3 Position
        {
            get;
            set;
        }

        /// <summary>
        /// Represents object's forward axis.
        /// </summary>
        Vector3 Forward
        {
            get;
        }

        /// <summary>
        /// Represents object's right axis.
        /// </summary>
        Vector3 Right
        {
            get;
        }

        /// <summary>
        /// Represents object's rotation on game field in eulerAngles.
        /// </summary>
        Vector3 Rotation
        {
            get;
            set;
        }

        /// <summary>
        /// Method, which used to activate\deactivate object on game field.
        /// </summary>
        /// <param name="active"></param>
        void SetActive(bool active);

        event Action<IActor> OnDisposeEvent;
    }
}
