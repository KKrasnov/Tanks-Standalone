using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Generics.Factory;

using TanksTest.Core.Actor.Tank;

namespace TanksTest.Core.Actor.Tank.Factory
{
    public interface ITankFactory : IFactory<ITank>
    {

    }
}
