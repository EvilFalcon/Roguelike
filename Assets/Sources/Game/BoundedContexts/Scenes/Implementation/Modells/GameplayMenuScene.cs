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
    /*
     * TODO : 1  сделать класс (модель) (Shop Upgratebl)
     * TODO : 2 сделать Сериализатор для классов (Player), (Hero) и (Shop Upgratebl)
     * TODO : 3 сделать Сервис для применения апгрэйтов при этом сотавить место для интеграции рекламы 
     * TODO : 4 сделать View для сцены GamePlayMenu
     * TODO : 5 Сделать согику для загрузки уравней
     */
}