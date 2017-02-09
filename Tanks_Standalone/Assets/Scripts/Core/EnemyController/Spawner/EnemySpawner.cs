using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor;
using TanksTest.Core.Actor.Enemy;
using TanksTest.Core.Actor.Enemy.Factory;

using TanksTest.Core.Camera;

namespace TanksTest.Core.Enemy.Spawner
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly BaseEnemyFactory _weakEnemyFactory;
        private readonly BaseEnemyFactory _middleEnemyFactory;
        private readonly BaseEnemyFactory _strongEnemyFactory;

        private readonly BaseCameraController _cameraController;

        private int _enemiesCountLimit;

        private List<BaseEnemy> _enemies;

        private bool _isSpawning = false;

        public EnemySpawner(BaseEnemyFactory weakEnemyFactory, BaseEnemyFactory middleEnemyFactory, BaseEnemyFactory strongEnemyFactory, BaseCameraController cameraController)
        {
            if (weakEnemyFactory == null)
                throw new ArgumentNullException("weakEnemyFactory");

            _weakEnemyFactory = weakEnemyFactory;

            if (middleEnemyFactory == null)
                throw new ArgumentNullException("middleEnemyFactory");

            _middleEnemyFactory = middleEnemyFactory;

            if (strongEnemyFactory == null)
                throw new ArgumentNullException("strongEnemyFactory");

            _strongEnemyFactory = strongEnemyFactory;

            if (cameraController == null)
                throw new ArgumentNullException("cameraController");

            _cameraController = cameraController;

            _enemies = new List<BaseEnemy>();
        }

        private void SpawnNewEnemy()
        {
            if (!_isSpawning)
                return;
            if (_enemies.Count >= _enemiesCountLimit)
                return;

            int spawnSeed = UnityEngine.Random.Range(0, 10);

            BaseEnemy enemy = null;

            if (spawnSeed < 2)
                enemy = _strongEnemyFactory.CreateObject();
            else if (spawnSeed < 6)
                enemy = _middleEnemyFactory.CreateObject();
            else 
                enemy = _weakEnemyFactory.CreateObject();

            enemy.transform.position = GetNewPosition();

            enemy.OnDisposeEvent += OnEnemyDisposedHandler;

            _enemies.Add(enemy);
        }

        private Vector3 GetNewPosition()
        {
            while (true)
            {
                Vector2 circlePos = UnityEngine.Random.insideUnitCircle.normalized * _cameraController.CameraRenderShape.width;
                Vector3 newPos = new Vector3(_cameraController.ObservedActor.transform.position.x + circlePos.x, 0, _cameraController.ObservedActor.transform.position.z + circlePos.y);
                if (newPos.x <= _cameraController.GameFieldConstrains.x || newPos.x >= _cameraController.GameFieldConstrains.x + _cameraController.GameFieldConstrains.width ||
                    newPos.z <= _cameraController.GameFieldConstrains.y || newPos.z >= _cameraController.GameFieldConstrains.y + _cameraController.GameFieldConstrains.height)
                    continue;
                return newPos;
            }
        }

        public void Init()
        {
        }

        public void StartSpawnEnemies(int enemiesCountLimit)
        {
            _isSpawning = true;
            _enemiesCountLimit = enemiesCountLimit;
            for (int i = 0; i < _enemiesCountLimit; i++)
                SpawnNewEnemy();
        }

        public void StopSpawnEnemies()
        {
            _isSpawning = false;
            for (int i = 0; i < _enemies.Count; i++)
            {
                _weakEnemyFactory.DestroyObject(_enemies[i]);
            }

            _enemies.Clear();
        }

        private void OnEnemyDisposedHandler(BaseActor actor)
        {
            BaseEnemy enemy = actor as BaseEnemy;
            enemy.OnDisposeEvent -= OnEnemyDisposedHandler;
            _enemies.Remove(enemy);
            SpawnNewEnemy();
        }
    }
}
