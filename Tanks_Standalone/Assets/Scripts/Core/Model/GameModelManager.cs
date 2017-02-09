using System;
using System.Collections;
using System.Collections.Generic;

using System.IO;

using System.Xml;
using System.Xml.Serialization;

using UnityEngine;

namespace TanksTest.Core.Model
{
    public class GameModelManager : IGameModelManager
    {
        private readonly string _configFilePath;

        private IGameModel _cachedGameModel;

        public GameModelManager(string configFilePath)
        {
            if (configFilePath == null)
                throw new ArgumentNullException("configFilePath");

            _configFilePath = configFilePath;
        }

        public IGameModel LoadGameModel()
        {
            if (!File.Exists(_configFilePath))
                return new GameModel();
            XmlSerializer serializer = new XmlSerializer(typeof(GameModel));
            TextReader reader = new StreamReader(_configFilePath);

            GameModel gameModel = serializer.Deserialize(reader) as GameModel;

            reader.Close();

            if (gameModel == null)
                return new GameModel();

            return gameModel;
        }

        public void SaveGameModel(IGameModel gameModel)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameModel));
            TextWriter writer = new StreamWriter(_configFilePath);
            serializer.Serialize(writer, gameModel);
            writer.Close();
        }
    }
}
