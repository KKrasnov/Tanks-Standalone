using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TanksTest.Core.Actor;

namespace TanksTest.Core.Camera
{
    public class CameraControllerHolder : BaseCameraController
    {
        [SerializeField]
        private string _objectName;

        private BaseCameraController _current;

        private BaseCameraController _Current
        {
            get
            {
                if (_current == null)
                    _current = FindNewInstance();
                return _current;
            }
        }

        public override Rect GameFieldConstrains
        {
            get
            {
                return _Current.GameFieldConstrains;
            }
        }

        public override Rect CameraRenderShape
        {
            get
            {
                return _Current.CameraRenderShape;
            }
        }

        public override BaseActor ObservedActor
        {
            get
            {
                return _Current.ObservedActor;
            }
            set
            {
                _Current.ObservedActor = value;
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

        private BaseCameraController FindNewInstance()
        {
            GameObject currentObj = GameObject.Find(_objectName);

            if (currentObj == null)
                return null;

            BaseCameraController current = currentObj.GetComponent<BaseCameraController>();

            if (current == null)
                return null;

            return current;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }
    }
}