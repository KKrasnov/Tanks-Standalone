using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor.Tank;

namespace TanksTest.Core.Actor.Tank.Factory
{
    public class TankFactory : MonoBehaviour, ITankFactory
    {
        [SerializeField]
        private GameObject _tankPrefab;

        public ITank CreateObject()
        {
            GameObject tankObj = GameObject.Instantiate(_tankPrefab);
            return tankObj.GetComponent<ITank>();
        }

        public void DestroyObject(ITank tank)
        {
            tank.Dispose();
        }
    }
}
