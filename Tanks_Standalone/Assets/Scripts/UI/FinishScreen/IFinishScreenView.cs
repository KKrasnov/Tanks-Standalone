using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Model;

using TanksTest.UI;

namespace TanksTest.UI.FinishScreen
{
    public interface IFinishScreenView : IUIView<IGameModel>
    {
        event Action OnRestartClickEvent;
        event Action OnBackToMainClickEvent;
    }
}
