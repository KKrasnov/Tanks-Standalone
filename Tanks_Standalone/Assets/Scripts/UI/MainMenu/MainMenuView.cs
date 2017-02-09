using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using TanksTest.Core.Model;

namespace TanksTest.UI.MainMenu
{
    public class MainMenuView : MonoBehaviour, IMainMenuView
    {
        [SerializeField]
        private Button _btnStartGame;

        public event Action OnStartGameClickEvent;

        private void Awake()
        {
            _btnStartGame.onClick.AddListener(new UnityAction(OnStartGameButtonClickHandler));
        }

        public void UpdateView(IGameModel model)
        {
        }

        public void SetVisible(bool visible)
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