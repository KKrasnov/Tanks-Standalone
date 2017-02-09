using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using TanksTest.Core.Model;

namespace TanksTest.UI.MainMenu
{
    public class MainMenuViewHolder : IMainMenuView
    {
        private readonly string _objectName;

        private IMainMenuView _current;

        private IMainMenuView _Current
        {
            get
            {
                if (_current == null)
                    _current = FindNewInstance();
                return _current;
            }
        }

        public event Action OnStartGameClickEvent
        {
            add
            {
                _Current.OnStartGameClickEvent += value;
            }
            remove
            {
                _Current.OnStartGameClickEvent -= value;
            }
        }

        public MainMenuViewHolder(string objectName)
        {
            if (objectName == null)
                throw new ArgumentNullException("objectName");

            _objectName = objectName;
        }

        private IMainMenuView FindNewInstance()
        {
            IMainMenuView current = GameObject.Find(_objectName).GetComponent<IMainMenuView>();

            return current;
        }

        public void UpdateView(IGameModel model)
        {
            _Current.UpdateView(model);
        }

        public void SetVisible(bool visible)
        {
            _Current.SetVisible(visible);
        }
    }
}