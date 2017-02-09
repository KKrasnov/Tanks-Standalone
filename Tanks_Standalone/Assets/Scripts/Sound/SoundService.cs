using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksTest.Sound
{
    public abstract class SoundService : MonoBehaviour
    {
        private static SoundService _inst;

        public static SoundService Instance
        {
            get
            {
                if (_inst == null)
                {
                    _inst = GameObject.Find("SoundService").GetComponent<SoundService>();
                }
                return _inst;
            }
            protected set
            {
                _inst = value;
            }
        }
    }
}