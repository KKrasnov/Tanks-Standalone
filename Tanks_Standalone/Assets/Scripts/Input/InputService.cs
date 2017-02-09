using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.PlayerInput
{
    public abstract class InputService : MonoBehaviour
    {
        private static InputService _inst;

        public static InputService Instance
        {
            get
            {
                if (_inst == null)
                {
                    _inst = GameObject.Find("InputService").GetComponent<InputService>();
                }
                return _inst;
            }
            protected set
            {
                _inst = value;
            }
        }

        public event Action OnPrevWeaponClickEvent;
        public event Action OnNextWeaponClickEvent;

        public event Action OnMoveForwardClickEvent;
        public event Action OnMoveBackwardClickEvent;
        public event Action OnTurnLeftClickEvent;
        public event Action OnTurnRightClickEvent;

        public event Action<float, float> OnMousePositionChangedEvent;

        public event Action OnFireClickEvent;

        public abstract Vector2 MouseScreenPosition
        {
            get;
        }

        protected virtual void OnPrevWeaponBtnClickHandler()
        {
            if (OnPrevWeaponClickEvent != null)
                OnPrevWeaponClickEvent();
        }

        protected virtual void OnNextWeaponBtnClickHandler()
        {
            if (OnNextWeaponClickEvent != null)
                OnNextWeaponClickEvent();
        }

        protected virtual void OnMoveForwardBtnClickHandler()
        {
            if (OnMoveForwardClickEvent != null)
                OnMoveForwardClickEvent();
        }

        protected virtual void OnMoveBackwardBtnClickHandler()
        {
            if (OnMoveBackwardClickEvent != null)
                OnMoveBackwardClickEvent();
        }

        protected virtual void OnTurnLeftBtnClickHandler()
        {
            if (OnTurnLeftClickEvent != null)
                OnTurnLeftClickEvent();
        }

        protected virtual void OnTurnRightBtnClickHandler()
        {
            if (OnTurnRightClickEvent != null)
                OnTurnRightClickEvent();
        }

        protected virtual void OnFireBtnClickHandler()
        {
            if (OnFireClickEvent != null)
                OnFireClickEvent();
        }

        protected virtual void OnMousePositionChangedHandler(float x, float y)
        {
            if (OnMousePositionChangedEvent != null)
                OnMousePositionChangedEvent(x, y);
        }
    }
}
