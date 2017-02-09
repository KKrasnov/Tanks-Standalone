using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Model;

using TanksTest.UI;

namespace TanksTest.UI.FinishScreen
{
    public interface IFinishScreenController : IUIController<IFinishScreenView, IGameModel>
    {
        event Action OnRestartEvent;
        event Action OnBackToMainEvent;
    }
}
