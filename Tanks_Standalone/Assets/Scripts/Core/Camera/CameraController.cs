using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor;

namespace TanksTest.Core.Camera
{
    public class CameraController : BaseCameraController
    {
        [SerializeField]
        private UnityEngine.Camera _camera;

        [SerializeField]
        private Rect _gameFieldConstrains;

        public  override Rect GameFieldConstrains
        {
            get
            {
                return _gameFieldConstrains;
            }
        }

        public override Rect CameraRenderShape
        {
            get
            {
                return GetCameraRenderShape();
            }
        }

        private BaseActor _observerActor;

        public override BaseActor ObservedActor
        {
            get
            {
                return _observerActor;
            }
            set
            {
                _observerActor = value;

            }
        }

        private void Update()
        {
            if (_observerActor == null) return;

            Vector3 newPosition = new Vector3(Mathf.Clamp(ObservedActor.transform.position.x, _gameFieldConstrains.x, _gameFieldConstrains.x + _gameFieldConstrains.width), 
                transform.position.y, Mathf.Clamp(ObservedActor.transform.position.z, _gameFieldConstrains.y, _gameFieldConstrains.y + _gameFieldConstrains.height));

            transform.position = newPosition;

            //transform.eulerAngles = new Vector3(transform.eulerAngles.x, ObservedActor.Rotation.y, transform.eulerAngles.z);
        }

        private Rect GetCameraRenderShape()
        {
            Rect rect = new Rect();
            Vector3 leftBottomPosition = _camera.ViewportToWorldPoint(Vector3.zero);
            rect.x = leftBottomPosition.x;
            rect.y = leftBottomPosition.z;
            Vector3 rightTopPosition = _camera.ViewportToWorldPoint(Vector3.one);
            rect.width = rightTopPosition.x - leftBottomPosition.x;
            rect.height = rightTopPosition.z - leftBottomPosition.z;
            return rect;
        }
    }
}
