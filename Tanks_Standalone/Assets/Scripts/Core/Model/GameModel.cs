using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace TanksTest.Core.Model
{
    public class GameModel : IGameModel
    {
        private int _currentScore = 0;

        [XmlIgnore]
        public int CurrentScore
        {
            get
            {
                return _currentScore;
            }
            set
            {
                _currentScore = value;
                if(OnModelChangedEvent != null)
                    OnModelChangedEvent();
            }
        }

        private int _lastScore = 0;

        [XmlIgnore]
        public int LastScore
        {
            get
            {
                return _lastScore;
            }
            set
            {
                _lastScore = value;
                if(OnModelChangedEvent != null)
                    OnModelChangedEvent();
            }
        }

        private int _bestScore = 0;

        public int BestScore
        {
            get
            {
                return _bestScore;
            }
            set
            {
                _bestScore = value;
                if (OnModelChangedEvent != null)
                    OnModelChangedEvent();
                if (OnConfigurationModelChangedEvent != null)
                    OnConfigurationModelChangedEvent();
            }
        }

        private int _coins = 0;

        public int Coins
        {
            get
            {
                return _coins;
            }
            set
            {
                _coins = value;
                if (OnModelChangedEvent != null)
                    OnModelChangedEvent();
                if (OnConfigurationModelChangedEvent != null)
                    OnConfigurationModelChangedEvent();
            }
        }

        private bool _soundEnabled = true;

        public bool SoundEnabled
        {
            get
            {
                return _soundEnabled;
            }
            set
            {
                _soundEnabled = value;
                if (OnModelChangedEvent != null)
                    OnModelChangedEvent();
                if (OnConfigurationModelChangedEvent != null)
                    OnConfigurationModelChangedEvent();
            }
        }

        private bool _isNoAds = false;

        public bool IsNoAds
        {
            get
            {
                return _isNoAds;
            }
            set
            {
                _isNoAds = value;
                if (OnConfigurationModelChangedEvent != null)
                    OnConfigurationModelChangedEvent();
            }
        }

        private string _selectedPlatformSkin;

        public string SelectedPlatformSkin
        {
            get
            {
                if (_selectedPlatformSkin == null)
                    _selectedPlatformSkin = _obtainedPlatformSkins[0];
                return _selectedPlatformSkin;
            }
            set
            {
                _selectedPlatformSkin = value;
                if (OnModelChangedEvent != null)
                    OnModelChangedEvent();
                if (OnConfigurationModelChangedEvent != null)
                    OnConfigurationModelChangedEvent();
            }
        }

        private List<string> _obtainedPlatformSkins = new List<string>(){"skin_default"};

        public List<string> ObtainedPlatformSkins
        {
            get;
            set;
        }

        public event Action OnModelChangedEvent;
        public event Action OnConfigurationModelChangedEvent;

        public GameModel()
        {
        }
    }
}
