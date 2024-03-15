using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Heroes.Implementation.Factories;
using Sources.Game.BoundedContexts.Players.Implementation.PlayerFactories.PlayerViewFactories;
using Sources.Game.BoundedContexts.Players.Interfaces;
using Sources.Game.BoundedContexts.Scenes.Implementation.Modells;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Factories;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Factories
{
    public class GameplaySceneFactory : ISceneFactory
    {
        private readonly IAssetService _assetService;
        private readonly HeroViewFactory _heroViewFactory;
        private readonly HeroModelFactory _heroFactory;
        private readonly IPlayer _player;

        public GameplaySceneFactory(IAssetService assetService, HeroViewFactory heroViewFactory,HeroModelFactory heroFactory, IPlayer player)
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _heroViewFactory = heroViewFactory ?? throw new ArgumentNullException(nameof(heroViewFactory));
            _heroFactory = heroFactory ?? throw new ArgumentNullException(nameof(heroFactory));
            _player = player ?? throw new ArgumentNullException(nameof(player));
        }

        public IScene Create(ISceneSwitcher sceneSwitcher) =>
            new GameplayScene(sceneSwitcher, _assetService, _heroViewFactory, _heroFactory, _player);
    }
}