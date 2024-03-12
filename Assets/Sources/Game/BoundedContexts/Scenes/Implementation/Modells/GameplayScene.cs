using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Players.Implementation.PlayerFactories.PlayerModelFactories;
using Sources.Game.BoundedContexts.Players.Implementation.PlayerFactories.PlayerViewFactories;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Modells
{
    public class GameplayScene : IScene
    {
        private readonly IAssetService _assetService;
        private readonly PlayerFactory _playerFactory;
        private readonly PlayerViewFactory _playerViewFactory;

        public GameplayScene(IAssetService assetService, PlayerFactory playerFactory, PlayerViewFactory playerViewFactory)
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
            _playerViewFactory = playerViewFactory ?? throw new ArgumentNullException(nameof(playerViewFactory));
        }

        public async void Enter()
        {
            await _assetService.LoadAsync();

            var player = _playerFactory.Create();
            _playerViewFactory.Create(player);
        }

        public void Exit()
        {
            _assetService.Release();
        }
    }
}