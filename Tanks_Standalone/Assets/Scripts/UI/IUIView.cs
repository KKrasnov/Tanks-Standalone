using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.UI
{
    public interface IUIView<T>
    {
        void UpdateView(T model);

        void SetVisible(bool visible);
    }
}
