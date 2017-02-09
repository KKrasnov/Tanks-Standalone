using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using TanksTest.PlayerInput;

using TanksTest.Core.Model;

namespace TanksTest.UI.FinishScreen
{
    public class FinishScreenView : MonoBehaviour, IFinishScreenView
    {
        [SerializeField]
        private Button _btnRestart;

        public event Action OnBackToMainClickEvent;
        public event Action OnRestartClickEvent;

        void Awake()
        {
            _btnRestart.onClick.AddListener(new UnityAction(OnRestartBtnClickHandler));
        }

        public void UpdateView(IGameModel gameModel)
        {
        }

        public void SetVisible(bool visible)
        {
            gameObject.SetActive(visible);
        }

        private void OnRestartBtnClickHandler()
        {
            if (OnRestartClickEvent != null)
                OnRestartClickEvent();
        }
    }
}
