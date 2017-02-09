using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Player;

namespace TanksTest.UI.HUD
{
    public class HUDController : IHUDController
    {
        private readonly IPlayerController _playerController;

        public BaseHUDView View
        {
            get;
            private set;
        }

        public event Action OnActionEvent;

        public HUDController(BaseHUDView hudView, IPlayerController playerController)
        {
            if (hudView == null)
                throw new ArgumentNullException("hudView");

            View = hudView;

            if (playerController == null)
                throw new ArgumentNullException("playerController");

            _playerController = playerController;

            _playerController.OnPlayerObjectHealthChangedEvent += OnPlayerObjectHealthChangedHandler;
        }

        public void SetActive(bool active)
        {
            View.SetVisible(active);
        }

        private void OnPlayerObjectHealthChangedHandler(int current, int max)
        {
            View.UpdateView(new int[] { current, max });
        }
    }
}
