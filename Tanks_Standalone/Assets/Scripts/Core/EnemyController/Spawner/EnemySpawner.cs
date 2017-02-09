using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

using TanksTest.Core.Actor;
using TanksTest.Core.Actor.Enemy;
using TanksTest.Core.Actor.Enemy.Factory;

using TanksTest.Core.Camera;

namespace TanksTest.Core.Enemy.Spawner
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly IEnemyFactory _enemyFactory;

        private readonly ICameraController _cameraController;

        private readonly int _enemiesCountLimit;

        private Timer _spawnTimer;

        private List<IEnemy> _enemies;

        public EnemySpawner(IEnemyFactory enemyFactory, ICameraController cameraController, int enemiesCountLimit)
        {
            if (enemyFactory == null)
                throw new ArgumentNullException("enemyFactory");

            _enemyFactory = enemyFactory;

            if (cameraController == null)
                throw new ArgumentNullException("cameraController");

            _cameraController = cameraController;

            _enemiesCountLimit = enemiesCountLimit;

            _enemies = new List<IEnemy>();
        }

        private void SpawnNewEnemy()
        {
            if (_enemies.Count >= _enemiesCountLimit) return;

            IEnemy enemy = _enemyFactory.CreateObject();

            /*enemy.Position = new Vector3(Mathf.Clamp(0, _cameraController.GameFieldConstrains.x, _cameraController.GameFieldConstrains.x + _cameraController.GameFieldConstrains.width), 0,
                Mathf.Clamp(0, _cameraController.GameFieldConstrains.y, _cameraController.GameFieldConstrains.y + _cameraController.GameFieldConstrains.height));*/

            enemy.OnDisposeEvent += OnEnemyDisposedHandler;

            _enemies.Add(enemy);
        }

        public void Init()
        {
        }

        public void StartSpawnEnemies()
        {
            _spawnTimer = new Timer(OnTimerTickedHandler, null, 0, 5000);
        }

        public void StopSpawnEnemies()
        {
            foreach (IEnemy enemy in _enemies)
                _enemyFactory.DestroyObject(enemy);

            if (_spawnTimer != null)
                _spawnTimer.Dispose();

            _enemies.Clear();
        }

        private void OnEnemyDisposedHandler(IActor actor)
        {
            _enemies.Remove(actor as IEnemy);
            SpawnNewEnemy();
        }

        private void OnTimerTickedHandler(object stateInfo)
        {
            if (_enemies.Count >= _enemiesCountLimit) _spawnTimer.Dispose();
            SpawnNewEnemy();
        }
    }
}
