using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Model;

using TanksTest.UI;

namespace TanksTest.UI.MainMenu
{
    public interface IMainMenuController : IUIController<IMainMenuView, IGameModel>
    {
        event Action OnStartGameEvent;
    }
}
