using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core.Model;

using TanksTest.UI;

namespace TanksTest.UI.MainMenu
{
    public abstract class BaseMainMenuView : UIView<IGameModel>
    {
        public abstract event Action OnStartGameClickEvent;
    }
}
