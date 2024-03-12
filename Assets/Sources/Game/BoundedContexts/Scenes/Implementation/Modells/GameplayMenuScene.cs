using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Modells
{
    public class GameplayMenuScene : IScene
    {
        private readonly IAssetService _assetService;

        public GameplayMenuScene(IAssetService assetService)
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
        }

        public async void Enter()
        {
            await _assetService.LoadAsync();
        }

        public void Exit()
        {
        }
    }
}