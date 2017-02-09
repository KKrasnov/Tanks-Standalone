using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core;
using TanksTest.Core.Camera;
using TanksTest.Core.Model;
using TanksTest.Core.Configuration;
using TanksTest.Core.Player;
using TanksTest.Core.Enemy;
using TanksTest.Core.Enemy.Spawner;
using TanksTest.Core.Actor.Tank.Factory;
using TanksTest.Core.Actor.Enemy.Factory;
using TanksTest.Core.Camera;

using TanksTest.UI.MainMenu;
using TanksTest.UI.HUD;

namespace TanksTest
{
    public class ApplicationEntry : MonoBehaviour
    {
        private static ApplicationEntry _inst;

        private AppMain _app = null;

        /// <summary>
        /// preffered application startup point
        /// </summary>
        void Awake()
        {
            if (_inst != null)
                GameObject.Destroy(this.gameObject);

            _inst = this;

            DontDestroyOnLoad(this.gameObject);

            IGameModel gameModel = new GameModel();

            BaseCameraController cameraController = GameObject.Find("CameraControllerHolder").GetComponent<BaseCameraController>();
            BaseTankFactory tankFactory = GameObject.Find("TankFactoryHolder").GetComponent<BaseTankFactory>();
            BaseEnemyFactory weakEnemyFactory = GameObject.Find("WeakEnemyFactoryHolder").GetComponent<BaseEnemyFactory>();
            BaseEnemyFactory middleEnemyFactory = GameObject.Find("MiddleEnemyFactoryHolder").GetComponent<BaseEnemyFactory>();
            BaseEnemyFactory strongEnemyFactory = GameObject.Find("StrongEnemyFactoryHolder").GetComponent<BaseEnemyFactory>();

            IEnemySpawner enemySpawner = new EnemySpawner(weakEnemyFactory, middleEnemyFactory, strongEnemyFactory, cameraController);

            IPlayerController playerController = new PlayerController(tankFactory, cameraController);

            BaseMainMenuView mainMenuView = GameObject.Find("MainMenuHolder").GetComponent<BaseMainMenuView>();
            IMainMenuController mainMenuController = new MainMenuController(mainMenuView, gameModel);

            BaseHUDView hudView = GameObject.Find("HUDHolder").GetComponent<BaseHUDView>();
            IHUDController hudController = new HUDController(hudView, playerController);

            IGameMain gameMain = new GameMain(hudController, playerController, enemySpawner);

            _app = new AppMain(mainMenuController, gameMain);
        }

        void Start()
        {
            _app.Init();
        }

        void Update()
        {
            _app.Update();
        }

        void OnApplicationQuit()
        {
            _app.DeInit();
        }
    }
}
