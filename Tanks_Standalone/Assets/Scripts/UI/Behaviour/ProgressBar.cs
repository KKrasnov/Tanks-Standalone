using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace TanksTest.UI.Behaviour
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField]
        private Text _lblProgress;

        [SerializeField]
        private Image _imgProgress;

        public void ApplyView(int current, int total)
        {
            _lblProgress.text = string.Format("{0}/{1}", current, total);
            _imgProgress.rectTransform.localScale = new Vector3((float)current / (float)total, 1, 1);
        }
    }
}
