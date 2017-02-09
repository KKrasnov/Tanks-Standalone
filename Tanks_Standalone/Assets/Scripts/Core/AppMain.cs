using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TanksTest.UI.MainMenu;

namespace TanksTest.Core
{
    public class AppMain 
    {
        private readonly IMainMenuController MainMenuController;

        private readonly IGameMain GameMain;

        public AppMain(IMainMenuController mainMenuController, IGameMain gameMain)
        {
            if (mainMenuController == null)
                throw new ArgumentNullException("mainMenuController");

            MainMenuController = mainMenuController;

            if (gameMain == null)
                throw new ArgumentNullException("gameMain");

            GameMain = gameMain;
        }

        public void Init()
        {
            GameMain.Init();
            MainMenuController.OnStartGameEvent += OnStartGameHandler;
            GameMain.OnGameFinishedEvent += OnGameFinishedHandler;
            SceneManager.sceneLoaded += OnSceneLoadedHandler;
        }

        public void Update()
        {
            GameMain.Update();
        }

        public void DeInit()
        {
            GameMain.Deinit();
        }

        private void OnStartGameHandler()
        {
            MainMenuController.SetActive(false);
            SceneManager.LoadScene("GameLevel");
        }

        private void OnGameFinishedHandler()
        {
            SceneManager.LoadScene("Main");
        }

        private void OnSceneLoadedHandler(Scene scene, LoadSceneMode mode)
        {
            switch (scene.name)
            {
                case "Main":
                    MainMenuController.SetActive(true);
                    break;
                case "GameLevel":
                    GameMain.StartGame();
                    break;
                default:
                    break;
            }
        }
    }
}