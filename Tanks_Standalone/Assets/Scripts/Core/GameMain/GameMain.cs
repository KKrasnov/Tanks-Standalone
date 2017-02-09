using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TanksTest.PlayerInput;

using TanksTest.Core.Enemy.Spawner;
using TanksTest.Core.Player;
using TanksTest.Core.Model;

using TanksTest.UI.HUD;

namespace TanksTest.Core
{
    public class GameMain : IGameMain
    {
        private readonly IHUDController HUDController;

        private readonly IPlayerController PlayerController;

        private readonly IEnemySpawner EnemySpawner;

        private bool _isGameStarted;

        public event Action OnGameFinishedEvent;

        public GameMain(IHUDController hudController, IPlayerController playerController, IEnemySpawner enemySpawner)
        {
            if (hudController == null)
                throw new ArgumentNullException("hudController");

            HUDController = hudController;

            if (playerController == null)
                throw new ArgumentNullException("playerController");

            PlayerController = playerController;

            if (enemySpawner == null)
                throw new ArgumentNullException("enemySpawner");

            EnemySpawner = enemySpawner;
        }

        public void Init()
        {
        }

        public void StartGame()
        {
            PlayerController.OnPlayerObjectHealthChangedEvent += OnPlayerObjectHealthChangedHandler;
            PlayerController.StartGameProccess();
            EnemySpawner.StartSpawnEnemies(10);
            HUDController.SetActive(true);
        }

        public void Update()
        {
        }

        public void Deinit()
        {
            PlayerController.StopGameProccess();
            EnemySpawner.StopSpawnEnemies();
        }

        private void FinishGame()
        {
            _isGameStarted = false;

            PlayerController.StopGameProccess();
            EnemySpawner.StopSpawnEnemies();
            HUDController.SetActive(false);
            PlayerController.OnPlayerObjectHealthChangedEvent -= OnPlayerObjectHealthChangedHandler;

            if(OnGameFinishedEvent != null)
                OnGameFinishedEvent();
        }

        private void OnPlayerObjectHealthChangedHandler(int currentHP, int maxHP)
        {
            if (currentHP <= 0)
                FinishGame();
        }
    }
}
