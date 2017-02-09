using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core
{
    public interface IGameMain
    {
        event Action OnGameFinishedEvent;

        void Init();

        void StartGame();

        void Update();
    }
}
