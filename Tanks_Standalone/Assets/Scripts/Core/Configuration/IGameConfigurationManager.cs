using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Configuration
{
    public interface IGameConfigurationManager
    {
        IGameConfiguration LoadGameConfiguration();
    }
}
