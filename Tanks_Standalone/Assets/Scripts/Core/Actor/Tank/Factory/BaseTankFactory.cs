using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Generics.Factory;

using TanksTest.Core.Actor.Tank;

namespace TanksTest.Core.Actor.Tank.Factory
{
    public abstract class BaseTankFactory : MonoBehaviour, IFactory<BaseTank>
    {
        public abstract BaseTank CreateObject();

        public abstract void DestroyObject(BaseTank obj);
    }
}
