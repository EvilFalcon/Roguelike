using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Factories;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Model;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.View;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Views;
using Sources.Game.BoundedContexts.Maperis.Interfaces;
using Sources.Game.BoundedContexts.Players.Implementation.Factories.PlayerModelFactories;
using Sources.Game.BoundedContexts.Players.Implementation.Model;
using Sources.Game.BoundedContexts.Settings.Implementation.Factories.Views;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using Sources.Game.DataTransferObjects.Implementation.DTO;
using Sources.Game.DataTransferObjects.Implementation.DTO.Enemyes;
using Sources.Game.DataTransferObjects.Implementation.Services;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Models
{
    public class GameplayMenuScene : IScene
    {
        private readonly IAssetService _assetService;
        private readonly ISaveLoadedServices _saveLoadedServices;
        private readonly ISettingsModelProvider _settingsModelProvider;
        private readonly MainGameMenuViewFactory _gameMenuViewFactory;
        private readonly SettingsViewFactory _settingsViewFactory;
        private readonly UpgradeStatsViewFactory _upgradeStatsViewFactory;
        private readonly PlayerModelFactory _playerModelFactory;
        private readonly UpgradeStatsModelFactory _upgradeStatsModelFactory;
        private readonly IViewService _viewServices;

        public GameplayMenuScene
        (IAssetService assetService,
            ISaveLoadedServices saveLoadedGameProgressServices,
            ISettingsModelProvider settingsModelProvider,
            MainGameMenuViewFactory gameMenuViewFactory,
            SettingsViewFactory settingsViewFactory,
            UpgradeStatsViewFactory upgradeStatsViewFactory,
            PlayerModelFactory playerModelFactory,
            UpgradeStatsModelFactory upgradeStatsModelFactory,
            IViewService viewServices
        )
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _saveLoadedServices = saveLoadedGameProgressServices ??
                                  throw new ArgumentNullException(nameof(saveLoadedGameProgressServices));
            _settingsModelProvider = settingsModelProvider ?? throw new ArgumentNullException(nameof(settingsModelProvider));
            _gameMenuViewFactory = gameMenuViewFactory ?? throw new ArgumentNullException(nameof(gameMenuViewFactory));
            _settingsViewFactory = settingsViewFactory ?? throw new ArgumentNullException(nameof(settingsViewFactory));
            _upgradeStatsViewFactory =
                upgradeStatsViewFactory ?? throw new ArgumentNullException(nameof(upgradeStatsViewFactory));
            _playerModelFactory = playerModelFactory ?? throw new ArgumentNullException(nameof(playerModelFactory));
            _upgradeStatsModelFactory =
                upgradeStatsModelFactory ?? throw new ArgumentNullException(nameof(upgradeStatsModelFactory));
            _viewServices = viewServices ?? throw new ArgumentNullException(nameof(viewServices));
        }

        public async void Enter()
        {
            await _assetService.LoadAsync();
            Initialize();

            _viewServices.ShowForm(nameof(MainGameMenuView));
        }

        private void Initialize()
        {
            UpgradeStatsModel upgradeStatsModel = _upgradeStatsModelFactory.Create();
            Player player = _playerModelFactory.Create(); //TODO : переработать 
            _gameMenuViewFactory.Create(player);
            _settingsViewFactory.Create(_settingsModelProvider.Model);
            _upgradeStatsViewFactory.Create(upgradeStatsModel, player);
        }

        public void Exit()
        {
            _viewServices.HideFormAll();
        }
    }
}