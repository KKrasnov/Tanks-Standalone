using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using TanksTest.UI.Behaviour;

namespace TanksTest.UI.HUD
{
    public class HUDView : BaseHUDView
    {
        [SerializeField]
        private ProgressBar _progressBar;

        public override void UpdateView(int[] model)
        {
            _progressBar.ApplyView(model[0], model[1]);
        }

        public override void SetVisible(bool visible)
        {
            gameObject.SetActive(visible);
        }
    }
}
