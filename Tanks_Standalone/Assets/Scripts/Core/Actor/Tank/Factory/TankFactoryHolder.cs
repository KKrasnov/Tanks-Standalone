using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor.Tank;

namespace TanksTest.Core.Actor.Tank.Factory
{
    public class TankFactoryHolder : ITankFactory
    {
        private readonly string _objectName;

        private ITankFactory _current;

        private ITankFactory _Current
        {
            get
            {
                if (_current == null)
                    _current = FindNewInstance();
                return _current;
            }
        }

        public TankFactoryHolder(string objectName)
        {
            if (objectName == null)
                throw new ArgumentNullException("objectName");

            _objectName = objectName;
        }

        private ITankFactory FindNewInstance()
        {
            ITankFactory current = GameObject.Find(_objectName).GetComponent<ITankFactory>();

            return current;
        }

        public ITank CreateObject()
        {
            return _Current.CreateObject();
        }

        public void DestroyObject(ITank tank)
        {
            _Current.DestroyObject(tank);
        }
    }
}