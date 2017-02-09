using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Model;
using TanksTest.UI;

namespace TanksTest.UI.MainMenu
{
    public class MainMenuController : IMainMenuController
    {
        private readonly IGameModel _gameModel;

        public IMainMenuView View
        {
            get;
            private set;
        }

        public event Action OnStartGameEvent;

        public MainMenuController(IMainMenuView mainMenuView, IGameModel gameModel)
        {
            if (mainMenuView == null)
                throw new ArgumentNullException("mainMenuView");

            View = mainMenuView;

            if (gameModel == null)
                throw new ArgumentNullException("gameModel");

            _gameModel = gameModel;

            _gameModel.OnModelChangedEvent += OnGameModelChangedHandler;

            View.OnStartGameClickEvent += OnStartGameClickHandler;
        }

        public void SetActive(bool active)
        {
            View.SetVisible(active);
        }

        void OnGameModelChangedHandler()
        {
            View.UpdateView(_gameModel);
        }

        void OnStartGameClickHandler()
        {
            if (OnStartGameEvent != null)
                OnStartGameEvent();
        }
    }
}