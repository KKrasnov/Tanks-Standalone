using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TanksTest.Generics.Factory;

using TanksTest.Core.Actor.Enemy;

namespace TanksTest.Core.Actor.Enemy.Factory
{
    public class EnemyFactoryHolder : BaseEnemyFactory
    {
        [SerializeField]
        private string _objectName;

        private BaseEnemyFactory _current;

        private BaseEnemyFactory _Current
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

        private BaseEnemyFactory FindNewInstance()
        {
            GameObject currentObj = GameObject.Find(_objectName);

            if (currentObj == null)
                return null;

            BaseEnemyFactory current = currentObj.GetComponent<BaseEnemyFactory>();

            if (current == null)
                return null;

            return current;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        public override BaseEnemy CreateObject()
        {
            return _Current.CreateObject();
        }

        public override void DestroyObject(BaseEnemy obj)
        {
            _Current.DestroyObject(obj);
        }
    }
}