using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor;

namespace TanksTest.Core.Camera
{
    public interface ICameraController
    {
        Rect GameFieldConstrains
        {
            get;
        }

        IActor ObservedActor
        {
            get;
            set;
        }
    }
}
