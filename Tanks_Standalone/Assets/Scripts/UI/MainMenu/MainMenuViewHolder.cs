using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

using TanksTest.Core.Model;

namespace TanksTest.UI.MainMenu
{
    public class MainMenuViewHolder : BaseMainMenuView
    {
        [SerializeField]
        private string _objectName;

        private BaseMainMenuView _current;

        private BaseMainMenuView _Current
        {
            get
            {
                if (_current == null)
                    _current = FindNewInstance();
                return _current;
            }
        }

        private event Action _onStartGameClickEvent;

        public override event Action OnStartGameClickEvent
        {
            add
            {
                if (_Current != null)
                    _Current.OnStartGameClickEvent += value;
                _onStartGameClickEvent += value;
            }
            remove
            {
                if (_Current != null)
                    _Current.OnStartGameClickEvent -= value;
                _onStartGameClickEvent -= value;
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            if (_current == null)
                _current = FindNewInstance();
        }

        private BaseMainMenuView FindNewInstance()
        {
            GameObject currentObj = GameObject.Find(_objectName);

            if (currentObj == null)
                return null;

            BaseMainMenuView current = currentObj.GetComponent<BaseMainMenuView>();

            if (current == null)
                return null;

            current.OnStartGameClickEvent += _onStartGameClickEvent;

            return current;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        private void OnStartGameClickHandler()
        {
            if (_onStartGameClickEvent != null)
                _onStartGameClickEvent();
        }

        public override void UpdateView(IGameModel model)
        {
            _Current.UpdateView(model);
        }

        public override void SetVisible(bool visible)
        {
            _Current.SetVisible(visible);
        }
    }
}