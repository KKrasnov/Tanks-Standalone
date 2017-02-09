using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Actor
{
    public abstract class BaseActor : MonoBehaviour
    {
        public abstract event Action<BaseActor> OnDisposeEvent;
    }
}
