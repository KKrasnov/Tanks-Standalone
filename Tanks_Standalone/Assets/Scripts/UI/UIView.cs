using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.UI
{
    public abstract class UIView<T> : MonoBehaviour
    {
        public abstract void UpdateView(T model);

        public abstract void SetVisible(bool visible);
    }
}
