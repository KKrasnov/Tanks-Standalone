using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using TanksTest.UI.Behaviour;

namespace TanksTest.UI.HUD
{
    public class HUDView : MonoBehaviour, IHUDView
    {
        [SerializeField]
        private ProgressBar _progressBar;

        public void UpdateView(int[] model)
        {
            _progressBar.ApplyView(model[0], model[1]);
        }

        public void SetVisible(bool visible)
        {
            gameObject.SetActive(visible);
        }
    }
}
