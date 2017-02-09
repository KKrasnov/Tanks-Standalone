using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor;

namespace TanksTest.Core.Camera
{
    public abstract class BaseCameraController : MonoBehaviour
    {
        public abstract Rect GameFieldConstrains
        {
            get;
        }

        public abstract Rect CameraRenderShape
        {
            get;
        }

        public abstract BaseActor ObservedActor
        {
            get;
            set;
        }
    }
}
