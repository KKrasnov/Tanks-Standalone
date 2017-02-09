using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.UI
{
    public interface IUIController<T, TModel> where T : IUIView<TModel>
    {
        T View
        {
            get;
        }

        void SetActive(bool active);
    }
}
