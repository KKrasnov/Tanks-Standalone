using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Generics.Factory;

using TanksTest.Core.Actor.Enemy;

namespace TanksTest.Core.Actor.Enemy.Factory
{
    public abstract class BaseEnemyFactory : MonoBehaviour, IFactory<BaseEnemy>
    {
        public abstract BaseEnemy CreateObject();

        public abstract void DestroyObject(BaseEnemy obj);
    }
}