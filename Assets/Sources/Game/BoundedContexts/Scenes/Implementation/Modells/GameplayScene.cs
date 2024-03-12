using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Players.Implementation.PlayerFactories.PlayerModelFactories;
using Sources.Game.BoundedContexts.Players.Implementation.PlayerFactories.PlayerViewFactories;
using Sources.Game.BoundedContexts.Players.Interfaces;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Modells
{
    public class GameplayScene : IScene
    {
        private readonly IAssetService _assetService;
        private readonly HeroViewFactory _heroViewFactory;

        public GameplayScene(IAssetService assetService, IPlayer player, HeroViewFactory heroViewFactory)
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _heroViewFactory = heroViewFactory ?? throw new ArgumentNullException(nameof(heroViewFactory));
        }

        public async void Enter()
        {
            await _assetService.LoadAsync();

            
            _heroViewFactory.Create(player);
        }

        public void Exit()
        {
            _assetService.Release();
        }
    }
}