using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Heroes.Implementation.Factories;
using Sources.Game.BoundedContexts.Heroes.Implementation.Factories.Models;
using Sources.Game.BoundedContexts.Heroes.Implementation.Factories.Views;
using Sources.Game.BoundedContexts.Players.Implementation.Factories.PlayerModelFactories;
using Sources.Game.BoundedContexts.Scenes.Implementation.Models;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Factories;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using UniCtor.Contexts;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Factories
{
    public class GameplaySceneFactory : ISceneFactory
    {
        private readonly IAssetService _assetService;
        private readonly HeroViewFactory _heroViewFactory;
        private readonly HeroModelFactory _heroFactory;
        private readonly PlayerModelFactory _playerModelFactory;

        public GameplaySceneFactory
        (
            IAssetService assetService,
            HeroViewFactory heroViewFactory,
            HeroModelFactory heroFactory,
            PlayerModelFactory playerModelFactory
        )
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _heroViewFactory = heroViewFactory ?? throw new ArgumentNullException(nameof(heroViewFactory));
            _heroFactory = heroFactory ?? throw new ArgumentNullException(nameof(heroFactory));
            _playerModelFactory = playerModelFactory ?? throw new ArgumentNullException(nameof(playerModelFactory));
        }

        public IScene Create(ISceneSwitcher sceneSwitcher, ISceneContext sceneContext) =>
            new GameplayScene(sceneSwitcher, _assetService, _heroViewFactory, _heroFactory, _playerModelFactory.Create());
    }
}