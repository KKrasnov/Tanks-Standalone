using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Core.Actor
{
    public interface IDamager
    {
        float DamagePower
        {
            get;
        }
    }
}