using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Heroes.Implementation.Factories;
using Sources.Game.BoundedContexts.Players.Implementation.Factories.PlayerViewFactories;
using Sources.Game.BoundedContexts.Players.Interfaces;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Models
{
    public class GameplayScene : IScene
    {
        private readonly ISceneSwitcher _sceneSwitcher;
        private readonly IAssetService _assetService;
        private readonly HeroViewFactory _heroViewFactory;
        private readonly HeroModelFactory _heroFactory;
        private readonly IPlayer _player;

        public GameplayScene(ISceneSwitcher sceneSwitcher,IAssetService assetService, HeroViewFactory heroViewFactory,HeroModelFactory heroFactory, IPlayer player)
        {
            _sceneSwitcher = sceneSwitcher ?? throw new ArgumentNullException(nameof(sceneSwitcher));
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _heroViewFactory = heroViewFactory ?? throw new ArgumentNullException(nameof(heroViewFactory));
            _heroFactory = heroFactory ?? throw new ArgumentNullException(nameof(heroFactory));
            _player = player ?? throw new ArgumentNullException(nameof(player));
        }

        public async void Enter()
        {
            await _assetService.LoadAsync();
            var player = _heroFactory.Create(_player);
            
            _heroViewFactory.Create(player);
        }

        public void Exit()
        {
            _assetService.Release();
        }
    }
}