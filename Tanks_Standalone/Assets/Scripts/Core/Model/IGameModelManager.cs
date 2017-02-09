using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Model
{
    public interface IGameModelManager
    {
        IGameModel LoadGameModel();
        void SaveGameModel(IGameModel gameModel);
    }
}
