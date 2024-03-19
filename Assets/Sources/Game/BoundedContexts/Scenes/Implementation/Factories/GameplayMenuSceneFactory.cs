using System;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.Presenter;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.View;
using Sources.Game.BoundedContexts.Players.Implementation.Factories.PlayerModelFactories;
using Sources.Game.BoundedContexts.Scenes.Implementation.Models;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Factories;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using Sources.Game.BoundedContexts.ViewFormServices.Implementation;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using Sources.Game.DataTransferObjects.Implementation.Services;
using UniCtor.Contexts;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Factories
{
    public class GameplayMenuSceneFactory : ISceneFactory
    {
        private readonly IAssetService _assetService;
        private readonly DataSaveLoadedServices _saveLoadedServices;
        private readonly ISceneSwitcher _sceneSwitcher;
        private readonly AssetService<MainGameMenuAssetProvider> _gameMenuViewFactory;
        private readonly IFormService _formService;
        private readonly ISceneContext _dependencyResolver;

        public GameplayMenuSceneFactory
        (
            IAssetService assetService,
            DataSaveLoadedServices saveLoadedServices,
            ISceneSwitcher sceneSwitcher,
            AssetService<MainGameMenuAssetProvider> gameMenuViewFactory,
            IFormService formService
        )
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _saveLoadedServices = saveLoadedServices ?? throw new ArgumentNullException(nameof(saveLoadedServices));
            _sceneSwitcher = sceneSwitcher ?? throw new ArgumentNullException(nameof(sceneSwitcher));
            _gameMenuViewFactory = gameMenuViewFactory ?? throw new ArgumentNullException(nameof(gameMenuViewFactory));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public IScene Create(ISceneSwitcher sceneSwitcher, ISceneContext sceneContext)
        {
            PlayerFactory playerFactory = new PlayerFactory();
            MainGameMenuPresenterFactory mainGameMenuPresenterFactory =
                new MainGameMenuPresenterFactory(_formService, _sceneSwitcher);

            MainGameMenuViewFactory mainGameMenuViewFactory =
                new MainGameMenuViewFactory(mainGameMenuPresenterFactory, sceneContext, _gameMenuViewFactory, _formService);

            return new GameplayMenuScene
            (
                _assetService,
                _saveLoadedServices,
                mainGameMenuViewFactory,
                playerFactory,
                _formService
            );
        }
    }
}