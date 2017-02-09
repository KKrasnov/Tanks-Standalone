using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using TanksTest.Core.Model;

namespace TanksTest.UI.MainMenu
{
    public class MainMenuView : BaseMainMenuView
    {
        [SerializeField]
        private Button _btnStartGame;

        public override event Action OnStartGameClickEvent;

        private void Awake()
        {
            _btnStartGame.onClick.AddListener(new UnityAction(OnStartGameButtonClickHandler));
        }

        public override void UpdateView(IGameModel model)
        {
        }

        public override void SetVisible(bool visible)
        {
            gameObject.SetActive(visible);
        }

        private void OnStartGameButtonClickHandler()
        {
            if (OnStartGameClickEvent != null)
                OnStartGameClickEvent();
        }
    }
}