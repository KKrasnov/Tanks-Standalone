using System;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Xml.Serialization;

using UnityEngine;

namespace TanksTest.Core.Configuration
{
    public class GameConfigurationManager : IGameConfigurationManager
    {
        private readonly string _configurationNamePath;

        public GameConfigurationManager(string configurationNamePath)
        {
            if (configurationNamePath == null)
                throw new ArgumentNullException("configurationNamePath");

            _configurationNamePath = configurationNamePath;
        }

        public IGameConfiguration LoadGameConfiguration()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameConfiguration));

            TextAsset asset = Resources.Load(_configurationNamePath) as TextAsset;

            if (asset == null)
                throw new NullReferenceException("textAsset");

            TextReader tr = new StringReader(asset.text);

            GameConfiguration gameConfiguration = serializer.Deserialize(tr) as GameConfiguration;

            tr.Close();

            return gameConfiguration;
        }

        #region CREATE FILE
        private void SaveNew()
        {
            GameConfiguration gameConfiguration = new GameConfiguration();

            XmlSerializer serializer = new XmlSerializer(typeof(GameConfiguration));

            TextWriter tr = new StreamWriter(Application.persistentDataPath + "/GameConfiguration.xml");

            serializer.Serialize(tr, gameConfiguration);
        }
        #endregion
    }
}
