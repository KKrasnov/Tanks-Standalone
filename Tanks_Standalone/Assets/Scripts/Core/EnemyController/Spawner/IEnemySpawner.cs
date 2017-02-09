using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Enemy.Spawner
{
    public interface IEnemySpawner
    {
        void Init();

        void StartSpawnEnemies(int enemiesCountLimit);
        void StopSpawnEnemies();
    }
}