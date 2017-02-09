using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor.Tank;

namespace TanksTest.Core.Actor.Tank.Factory
{
    public class TankFactory : BaseTankFactory
    {
        [SerializeField]
        private GameObject _tankPrefab;

        public override BaseTank CreateObject()
        {
            GameObject tankObj = GameObject.Instantiate(_tankPrefab);
            return tankObj.GetComponent<BaseTank>();
        }

        public override void DestroyObject(BaseTank tank)
        {
            GameObject.Destroy(tank.gameObject);
        }
    }
}
