using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TanksTest.Core.Model;

namespace TanksTest.UI.HUD
{
    public class HUDViewHolder : BaseHUDView
    {
        [SerializeField]
        private string _objectName;

        private BaseHUDView _current;

        private BaseHUDView _Current
        {
            get
            {
                if (_current == null)
                    _current = FindNewInstance();
                return _current;
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

        private BaseHUDView FindNewInstance()
        {
            GameObject currentObj = GameObject.Find(_objectName);

            if (currentObj == null)
                return null;

            BaseHUDView current = currentObj.GetComponent<BaseHUDView>();

            if (current == null)
                return null;

            return current;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        public override void UpdateView(int[] model)
        {
            _Current.UpdateView(model);
        }

        public override void SetVisible(bool visible)
        {
            _Current.SetVisible(visible);
        }
    }
}
