using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Model
{
    public interface IGameModel
    {
        event Action OnModelChangedEvent;
    }
}
