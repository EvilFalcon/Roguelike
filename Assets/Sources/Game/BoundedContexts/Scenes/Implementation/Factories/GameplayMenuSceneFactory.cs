using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Players.Implementation.PlayerFactories.PlayerModelFactories;
using Sources.Game.BoundedContexts.Players.Implementation.PlayerFactories.PlayerViewFactories;
using Sources.Game.BoundedContexts.Scenes.Implementation.Modells;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Factories;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Factories
{
    public class GameplayMenuSceneFactory : ISceneFactory
    {
        private readonly IAssetService _assetService;
        private readonly PlayerFactory _playerFactory;

        public GameplayMenuSceneFactory(IAssetService assetService, HeroViewFactory heroViewFactory,
            PlayerFactory playerFactory)
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
        }

        public IScene Create(ISceneSwitcher sceneSwitcher) =>
            new GameplayMenuScene(_assetService);
    }
    
    
    
}