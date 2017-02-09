using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Generics.Factory
{
    public interface IFactory<T>
    {
        T CreateObject();
        void DestroyObject(T obj);
    }
}
