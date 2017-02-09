using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TanksTest.Core.Actor.Tank;

namespace TanksTest.Core.Actor.Tank.Factory
{
    public class TankFactoryHolder : BaseTankFactory
    {
        [SerializeField]
        private string _objectName;

        private BaseTankFactory _current;

        private BaseTankFactory _Current
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

        private BaseTankFactory FindNewInstance()
        {
            GameObject currentObj = GameObject.Find(_objectName);

            if (currentObj == null)
                return null;

            BaseTankFactory current = currentObj.GetComponent<BaseTankFactory>();

            if (current == null)
                return null;

            return current;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        public override BaseTank CreateObject()
        {
            return _Current.CreateObject();
        }

        public override void DestroyObject(BaseTank obj)
        {
            _Current.DestroyObject(obj);
        }
    }
}