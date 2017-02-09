using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.PlayerInput
{
    public class StandaloneInputService : InputService
    {
        private Vector3 _prevMouseScreenPosition;

        public override Vector2 MouseScreenPosition
        {
            get { return Input.mousePosition; }
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
                OnFireBtnClickHandler();
            if (Input.GetKey(KeyCode.W))
                OnMoveForwardBtnClickHandler();
            if (Input.GetKey(KeyCode.S))
                OnMoveBackwardBtnClickHandler();
            if (Input.GetKey(KeyCode.A))
                OnTurnLeftBtnClickHandler();
            if (Input.GetKey(KeyCode.D))
                OnTurnRightBtnClickHandler();
            if (Input.GetKeyDown(KeyCode.Q))
                OnPrevWeaponBtnClickHandler();
            if (Input.GetKeyDown(KeyCode.E))
                OnNextWeaponBtnClickHandler();

            if (Input.mousePosition != _prevMouseScreenPosition)
            {
                OnMousePositionChangedHandler(Input.mousePosition.x, Input.mousePosition.y);
                _prevMouseScreenPosition = Input.mousePosition;
            }
        }
    }
}
