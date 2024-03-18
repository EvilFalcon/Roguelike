using System;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Controllers;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.Presenter;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.View;
using Sources.Game.BoundedContexts.Players.Implementation.Factories.PlayerModelFactories;
using Sources.Game.BoundedContexts.Players.Implementation.PlayerFactories.PlayerViewFactories;
using Sources.Game.BoundedContexts.Scenes.Implementation.Modells;
using Sources.Game.BoundedContexts.Scenes.Implementation.Models;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Factories;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using Sources.Game.BoundedContexts.ViewFormServices.Implementation;
using Sources.Game.DataTransferObjects.Implementation.Services;
using UniCtor.Builders;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Factories
{
    public class GameplayMenuSceneFactory : ISceneFactory
    {
        private readonly IAssetService _assetService;
        private readonly DataSaveLoadedServices _saveLoadedServices;
        private readonly IDependencyResolver _dependencyResolver;

        public GameplayMenuSceneFactory
        (
            IAssetService assetService,
            DataSaveLoadedServices saveLoadedServices,
            IDependencyResolver dependencyResolver
        )
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _saveLoadedServices = saveLoadedServices ?? throw new ArgumentNullException(nameof(saveLoadedServices));
            _dependencyResolver = dependencyResolver ?? throw new ArgumentNullException(nameof(dependencyResolver));
        }

        public IScene Create(ISceneSwitcher sceneSwitcher)
        {
            FormServices formServices = new FormServices();
            AssetService<MainGameMenuAssetProvider> gameMenuViewFactory = new AssetService<MainGameMenuAssetProvider>();
            PlayerFactory playerFactory = new PlayerFactory();
            MainGameMenuPresenterFactory mainGameMenuPresenterFactory = new MainGameMenuPresenterFactory();
            
            MainGameMenuViewFactory mainGameMenuViewFactory =
                new MainGameMenuViewFactory(mainGameMenuPresenterFactory, _dependencyResolver, gameMenuViewFactory, formServices);
            
            return new GameplayMenuScene
            (
                _assetService,
                _saveLoadedServices,
                mainGameMenuViewFactory,
                playerFactory,
                formServices
            );
        }
    }
}