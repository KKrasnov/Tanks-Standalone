using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Generics.Factory;

using TanksTest.Core.Actor.Enemy;

namespace TanksTest.Core.Actor.Enemy.Factory
{
    public class EnemyFactory : BaseEnemyFactory
    {
        [SerializeField]
        private GameObject _enemyPrefab;

        public override BaseEnemy CreateObject()
        {
            GameObject enemyObj = GameObject.Instantiate(_enemyPrefab);
            return enemyObj.GetComponent<BaseEnemy>();
        }

        public override void DestroyObject(BaseEnemy obj)
        {
            GameObject.Destroy(obj.gameObject);
        }
    }
}