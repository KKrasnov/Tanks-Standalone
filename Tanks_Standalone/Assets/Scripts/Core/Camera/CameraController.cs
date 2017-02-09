using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor;

namespace TanksTest.Core.Camera
{
    public class CameraController : MonoBehaviour, ICameraController
    {
        [SerializeField]
        private Rect _gameFieldConstrains;

        public Rect GameFieldConstrains
        {
            get
            {
                return _gameFieldConstrains;
            }
        }

        public IActor ObservedActor
        {
            get;
            set;
        }

        private void Update()
        {
            if (ObservedActor == null)
                return;

            Vector3 newPosition = new Vector3(Mathf.Clamp(ObservedActor.Position.x, _gameFieldConstrains.x, _gameFieldConstrains.x + _gameFieldConstrains.width), 
                transform.position.y, Mathf.Clamp(ObservedActor.Position.z, _gameFieldConstrains.y, _gameFieldConstrains.y + _gameFieldConstrains.height));

            transform.position = newPosition;
        }
    }
}
