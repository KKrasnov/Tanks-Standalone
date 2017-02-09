using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TanksTest.Core;
using TanksTest.Core.Camera;
using TanksTest.Core.Model;
using TanksTest.Core.Configuration;
using TanksTest.Core.Player;
using TanksTest.Core.Actor.Tank.Factory;
using TanksTest.Core.Camera;

using TanksTest.UI.MainMenu;
using TanksTest.UI.FinishScreen;
using TanksTest.UI.HUD;

namespace TanksTest
{
    public class ApplicationEntry : MonoBehaviour
    {
        private AppMain _app = null;

        /// <summary>
        /// preffered application startup point
        /// </summary>
        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);

            IGameModel gameModel = new GameModel();

            ICameraController cameraController = new CameraControllerHolder("Main Camera");

            ITankFactory tankFactory = new TankFactoryHolder("TankFactory");

            IPlayerController playerController = new PlayerController(tankFactory, cameraController);

            IMainMenuView mainMenuView = new MainMenuViewHolder("MainMenu");
            IMainMenuController mainMenuController = new MainMenuController(mainMenuView, gameModel);

            IHUDView hudView = new HUDViewHolder("HUD");
            IHUDController hudController = new HUDController(hudView, playerController);

            IGameMain gameMain = new GameMain(hudController, playerController);

            _app = new AppMain(mainMenuController, gameMain);

            /*IGameConfigurationManager gameConfigurationManager = new GameConfigurationManager("Configuration/GameConfiguration");
            IGameConfiguration gameConfiguration = gameConfigurationManager.LoadGameConfiguration();

            IGameModelManager gameModelManager = new GameModelManager(Application.persistentDataPath + "/GameModel.xml");
            IGameModel gameModel = gameModelManager.LoadGameModel();

            IGameCurrencyManager gameCurrencyManager = new GameCurrencyManager(gameModel);

            IHUDView hudView = GameObject.Find("HUD").GetComponent<IHUDView>();
            IHUDController hudController = new HUDController(hudView, gameModel);

            IFinishScreenView finishScreenView = GameObject.Find("FinishScreen").GetComponent<IFinishScreenView>();
            IFinishScreenController finishScreenController = new FinishScreenController(finishScreenView, gameModel);

            IMainMenuView mainMenuView = GameObject.Find("MainMenu").GetComponent<IMainMenuView>();
            IMainMenuController mainMenuController = new MainMenuController(mainMenuView, gameModel);

            IShopScreenView shopScreenView = GameObject.Find("ShopScreen").GetComponent<IShopScreenView>();
            IShopScreenController shopScreenController = new ShopScreenController(shopScreenView, gameModel);

            IPlatformFactory platformFactory = GameObject.Find("PlatformFactory").GetComponent<IPlatformFactory>();

            ICameraController cameraController = GameObject.Find("Main Camera").GetComponent<ICameraController>();

            IGameMain gameMain = new GameMain(hudController, platformFactory, cameraController, gameModel, gameModelManager);

            _app = new AppMain(mainMenuController, shopScreenController, finishScreenController, gameMain);*/
        }

        void Start()
        {
            _app.Init();
        }

        void Update()
        {
            _app.Update();
        }

        void OnDestroy()
        {
            _app.DeInit();
        }
    }
}
