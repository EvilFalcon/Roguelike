using System;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Audio.Interfaces;
using Sources.Game.BoundedContexts.Localizations.Implementation.Services;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.Presenter;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.View;
using Sources.Game.BoundedContexts.Players.Implementation.Factories.PlayerModelFactories;
using Sources.Game.BoundedContexts.Scenes.Implementation.Models;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Factories;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using Sources.Game.BoundedContexts.Settings.Implementation.Controllers;
using Sources.Game.BoundedContexts.Settings.Implementation.Factories.Presenters;
using Sources.Game.BoundedContexts.Settings.Implementation.Factories.Views;
using Sources.Game.BoundedContexts.Settings.Interfaces;
using Sources.Game.BoundedContexts.ViewFormServices.Implementation;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using Sources.Game.DataTransferObjects.Implementation.Services;
using UniCtor.Contexts;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Factories
{
    public class GameplayMenuSceneFactory : ISceneFactory
    {
        private readonly IAssetService _assetService;
        private readonly ISaveLoadedGameProgresServices _saveLoadedGameProgresServices;
        private readonly ISceneSwitcher _sceneSwitcher;
        private readonly AssetService<MainGameMenuAssetProvider> _gameMenuViewFactory;
        private readonly AssetService<SettingsAssetProvider> _settingsAssetProvider;
        private readonly IAudioController _audioController;
        private readonly LocalizationService _localizationService;
        private readonly IFormService _formService;
        private readonly ISceneContext _dependencyResolver;

        public GameplayMenuSceneFactory
        (
            IAssetService assetService,
            ISaveLoadedGameProgresServices saveLoadedGameProgressServices,
            ISceneSwitcher sceneSwitcher,
            AssetService<MainGameMenuAssetProvider> gameMenuViewFactory,
            AssetService<SettingsAssetProvider> settingsAssetProvider,
            IAudioController audioController,
            LocalizationService localizationService,
            IFormService formService
        )
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));

            _saveLoadedGameProgresServices = saveLoadedGameProgressServices ??
                                             throw new ArgumentNullException(nameof(saveLoadedGameProgressServices));
            _sceneSwitcher = sceneSwitcher ?? throw new ArgumentNullException(nameof(sceneSwitcher));
            _gameMenuViewFactory = gameMenuViewFactory ?? throw new ArgumentNullException(nameof(gameMenuViewFactory));
            _settingsAssetProvider = settingsAssetProvider ?? throw new ArgumentNullException(nameof(settingsAssetProvider));
            _audioController = audioController ?? throw new ArgumentNullException(nameof(audioController));
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public IScene Create(ISceneSwitcher sceneSwitcher, ISceneContext sceneContext)
        {
            _localizationService.LoadLocalizationModel();
            PlayerFactory playerFactory = new PlayerFactory();
            MainGameMenuPresenterFactory mainGameMenuPresenterFactory =
                new MainGameMenuPresenterFactory(_formService, _sceneSwitcher, _localizationService);

            var settingsPresenterFactory = new SettingsPresenterFactory(_localizationService, _audioController, _formService);
            var settingsViewFactory =
                new SettingsViewFactory(settingsPresenterFactory, sceneContext, _settingsAssetProvider, _formService);

            MainGameMenuViewFactory mainGameMenuViewFactory =
                new MainGameMenuViewFactory(mainGameMenuPresenterFactory, sceneContext, _gameMenuViewFactory, _formService);

            return new GameplayMenuScene
            (
                _assetService,
                _saveLoadedGameProgresServices,
                mainGameMenuViewFactory,
                settingsViewFactory,
                playerFactory,
                _formService
            );
        }
    }
}