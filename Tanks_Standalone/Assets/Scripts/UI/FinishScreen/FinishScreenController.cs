using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Model;

namespace TanksTest.UI.FinishScreen
{
    public class FinishScreenController : IFinishScreenController
    {
        private readonly IGameModel _gameModel;

        public IFinishScreenView View
        {
            get;
            private set;
        }

        public event Action OnRestartEvent;
        public event Action OnBackToMainEvent;

        public FinishScreenController(IFinishScreenView finishScreenView, IGameModel gameModel)
        {
            if (finishScreenView == null)
                throw new ArgumentNullException("finishScreenView");

            View = finishScreenView;

            if (gameModel == null)
                throw new ArgumentNullException("gameModel");

            _gameModel = gameModel;

            finishScreenView.OnRestartClickEvent += OnRestartClickHandler;
            _gameModel.OnModelChangedEvent += OnCurrentScoreChangedHandler;
        }

        public void SetActive(bool active)
        {
            View.SetVisible(active);
        }

        private void OnRestartClickHandler()
        {
            if (OnRestartEvent != null)
                OnRestartEvent();
        }

        private void OnCurrentScoreChangedHandler()
        {
            View.UpdateView(_gameModel);
        }
    }
}