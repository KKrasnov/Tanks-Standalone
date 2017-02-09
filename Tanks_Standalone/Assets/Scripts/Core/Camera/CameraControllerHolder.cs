using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor;

namespace TanksTest.Core.Camera
{
    public class CameraControllerHolder : ICameraController
    {
        private readonly string _objectName;

        private ICameraController _current;

        private ICameraController _Current
        {
            get
            {
                if (_current == null)
                    _current = FindNewInstance();
                return _current;
            }
        }

        public Rect GameFieldConstrains
        {
            get
            {
                return _Current.GameFieldConstrains;
            }
        }

        public IActor ObservedActor
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

        public CameraControllerHolder(string objectName)
        {
            if (objectName == null)
                throw new ArgumentNullException("objectName");

            _objectName = objectName;
        }

        private ICameraController FindNewInstance()
        {
            ICameraController current = GameObject.Find(_objectName).GetComponent<ICameraController>();

            return current;
        }
    }
}