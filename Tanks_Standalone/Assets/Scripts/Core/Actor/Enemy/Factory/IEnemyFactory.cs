using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Generics.Factory;

using TanksTest.Core.Actor.Enemy;

namespace TanksTest.Core.Actor.Enemy.Factory
{
    public interface IEnemyFactory : IFactory<IEnemy>
    {

    }
}