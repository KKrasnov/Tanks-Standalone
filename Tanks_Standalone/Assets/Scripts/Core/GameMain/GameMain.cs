using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TanksTest.PlayerInput;

using TanksTest.Core.Player;
using TanksTest.Core.Model;

using TanksTest.UI.HUD;

namespace TanksTest.Core
{
    public class GameMain : IGameMain
    {
        private readonly IHUDController HUDController;

        private readonly IPlayerController PlayerController;

        private bool _isGameStarted;

        public event Action OnGameFinishedEvent;

        public GameMain(IHUDController hudController, IPlayerController playerController)
        {
            if (hudController == null)
                throw new ArgumentNullException("hudController");

            HUDController = hudController;

            if (playerController == null)
                throw new ArgumentNullException("playerController");

            PlayerController = playerController;
        }

        public void Init()
        {
            PlayerController.OnPlayerObjectHealthChangedEvent += OnPlayerObjectHealthChangedHandler;
        }

        public void StartGame()
        {
            PlayerController.StartGameProccess();
            HUDController.SetActive(true);
        }

        public void Update()
        {
        }

        private void FinishGame()
        {
            _isGameStarted = false;

            PlayerController.StopGameProccess();
            HUDController.SetActive(false);

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
