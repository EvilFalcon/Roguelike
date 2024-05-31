using System;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Factories;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Services;
using Sources.Game.BoundedContexts.Audio.Interfaces;
using Sources.Game.BoundedContexts.Localizations.Implementation.Services;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.Presenter;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.View;
using Sources.Game.BoundedContexts.Maperis.Interfaces;
using Sources.Game.BoundedContexts.Players.Implementation.Factories.PlayerModelFactories;
using Sources.Game.BoundedContexts.Scenes.Implementation.Models;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Factories;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using Sources.Game.BoundedContexts.Settings.Implementation.Factories.Presenters;
using Sources.Game.BoundedContexts.Settings.Implementation.Factories.Views;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using Sources.Game.Common.Models;
using Sources.Game.DataTransferObjects.Implementation.Services;
using UniCtor.Contexts;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Factories
{
    public class GameplayMenuSceneFactory : ISceneFactory
    {
        private readonly IAssetService _assetService;
        private readonly ISaveLoadedServices _saveLoadedServices;
        private readonly ISceneSwitcher _sceneSwitcher;
        private readonly ISettingsModelProvider _settingsModelProvider;
        private readonly AssetService<MainGameMenuAssetProvider> _gameMenuViewProvider;
        private readonly AssetService<SettingsAssetProvider> _settingsAssetProvider;
        private readonly AssetService<UpgradeStatsAssetProvider> _upgradeStatsViewProvider;
        private readonly ISoundController _soundController;
        private readonly IMusicController _musicController;
        private readonly LocalizationService _localizationService;
        private readonly PlayerModelFactory _playerModelFactory;
        private readonly UpgradableService _upgradableService;
        private readonly UpgradeStatsModelFactory _upgradeStatsModelFactory;
        private readonly IViewService _viewService;
        private readonly ModelRepository _modelRepository;
        private readonly ISceneContext _dependencyResolver;

        public GameplayMenuSceneFactory
        (
            IAssetService assetService,
            ISaveLoadedServices saveLoadedGameProgressServices,
            ISceneSwitcher sceneSwitcher,
            ISettingsModelProvider settingsModelProvider,
            AssetService<MainGameMenuAssetProvider> gameMenuViewProvider,
            AssetService<SettingsAssetProvider> settingsAssetProvider,
            AssetService<UpgradeStatsAssetProvider> upgradeStatsViewProvider,
            ISoundController soundController,
            IMusicController musicController,
            LocalizationService localizationService,
            PlayerModelFactory playerModelFactory,
            UpgradableService upgradableService,
            UpgradeStatsModelFactory upgradeStatsModelFactory,
            IViewService viewService,
            ModelRepository modelRepository
        )
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));

            _saveLoadedServices = saveLoadedGameProgressServices ??
                                  throw new ArgumentNullException(nameof(saveLoadedGameProgressServices));
            _sceneSwitcher = sceneSwitcher ?? throw new ArgumentNullException(nameof(sceneSwitcher));
            _settingsModelProvider = settingsModelProvider ?? throw new ArgumentNullException(nameof(settingsModelProvider));
            _gameMenuViewProvider = gameMenuViewProvider ?? throw new ArgumentNullException(nameof(gameMenuViewProvider));
            _settingsAssetProvider = settingsAssetProvider ?? throw new ArgumentNullException(nameof(settingsAssetProvider));
            _upgradeStatsViewProvider =
                upgradeStatsViewProvider ?? throw new ArgumentNullException(nameof(upgradeStatsViewProvider));
            _soundController = soundController ?? throw new ArgumentNullException(nameof(soundController));
            _musicController = musicController ?? throw new ArgumentNullException(nameof(musicController));
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
            _playerModelFactory = playerModelFactory ?? throw new ArgumentNullException(nameof(playerModelFactory));
            _upgradableService = upgradableService ?? throw new ArgumentNullException(nameof(upgradableService));
            _upgradeStatsModelFactory =
                upgradeStatsModelFactory ?? throw new ArgumentNullException(nameof(upgradeStatsModelFactory));

            _viewService = viewService ?? throw new ArgumentNullException(nameof(viewService));
            _modelRepository = modelRepository ?? throw new ArgumentNullException(nameof(modelRepository));
        }

        public IScene Create(ISceneSwitcher sceneSwitcher, ISceneContext sceneContext)
        {
            _localizationService.LoadLocalizationModel();
            MainGameMenuPresenterFactory mainGameMenuPresenterFactory =
                new MainGameMenuPresenterFactory(_viewService, _sceneSwitcher, _localizationService, _soundController);

            var settingsPresenterFactory =
                new SettingsPresenterFactory(_localizationService, _soundController, _musicController, _viewService);
            var settingsViewFactory =
                new SettingsViewFactory(settingsPresenterFactory, sceneContext, _settingsAssetProvider, _viewService);

            MainGameMenuViewFactory mainGameMenuViewFactory =
                new MainGameMenuViewFactory(mainGameMenuPresenterFactory, sceneContext, _gameMenuViewProvider, _viewService);

            UpgradeStatsViewFactory upgradeStatsViewFactory = new UpgradeStatsViewFactory
            (
                sceneContext,
                _viewService,
                new UpgradeStatsPresenterFactory
                (
                    _localizationService,
                    _upgradableService,
                    _viewService
                ),
                _upgradeStatsViewProvider
            );

            return new GameplayMenuScene
            (
                _assetService,
                _saveLoadedServices,
                _settingsModelProvider,
                mainGameMenuViewFactory,
                settingsViewFactory,
                upgradeStatsViewFactory,
                _playerModelFactory,
                _upgradeStatsModelFactory,
                _viewService,
                _modelRepository
            );
        }
    }
}