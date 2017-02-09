using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Player
{
    public interface IPlayerController 
    {
        event Action<int,int> OnPlayerObjectHealthChangedEvent;

        void Init();

        void StartGameProccess();
        void StopGameProccess();
    }
}
