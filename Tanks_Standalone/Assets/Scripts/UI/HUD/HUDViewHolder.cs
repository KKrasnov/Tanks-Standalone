using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using TanksTest.Core.Model;

namespace TanksTest.UI.HUD
{
    public class HUDViewHolder : IHUDView
    {
        private readonly string _objectName;

        private IHUDView _current;

        private IHUDView _Current
        {
            get
            {
                if (_current == null)
                    _current = FindNewInstance();
                return _current;
            }
        }

        public HUDViewHolder(string objectName)
        {
            if (objectName == null)
                throw new ArgumentNullException("objectName");

            _objectName = objectName;
        }

        private IHUDView FindNewInstance()
        {
            IHUDView current = GameObject.Find(_objectName).GetComponent<IHUDView>();

            return current;
        }

        public void UpdateView(int[] model)
        {
            _Current.UpdateView(model);
        }

        public void SetVisible(bool visible)
        {
            _Current.SetVisible(visible);
        }
    }
}
