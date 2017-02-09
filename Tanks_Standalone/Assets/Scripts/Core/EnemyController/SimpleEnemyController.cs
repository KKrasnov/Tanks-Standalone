using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Actor;
using TanksTest.Core.Actor.Enemy;

namespace TanksTest.Core.Enemy
{
    public class SimpleEnemyController : BaseEnemyController
    {
        [SerializeField]
        private string _targetTag = "player";

        BaseActor _targetActor;

        BaseEnemy _controllableActor;

        void Awake()
        {
            _controllableActor = gameObject.GetComponent<BaseEnemy>();
            GameObject targetObject = GameObject.FindGameObjectWithTag(_targetTag);
            _targetActor = targetObject.GetComponent<BaseActor>();
        }

        void Update()
        {
            if (_targetActor == null) return;
            _controllableActor.MoveTo(_controllableActor.transform.forward);
            _controllableActor.RotateTo(_targetActor.transform.position);
        }
    }
}
