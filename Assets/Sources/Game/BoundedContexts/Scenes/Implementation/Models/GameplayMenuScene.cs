using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.View;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Views;
using Sources.Game.BoundedContexts.Maperis.Interfaces;
using Sources.Game.BoundedContexts.Players.Implementation.Factories.PlayerModelFactories;
using Sources.Game.BoundedContexts.Players.Implementation.LiveData;
using Sources.Game.BoundedContexts.Players.Implementation.Model;
using Sources.Game.BoundedContexts.Settings.Implementation.Factories.Views;
using Sources.Game.BoundedContexts.Settings.Implementation.Models;
using Sources.Game.BoundedContexts.Settings.Implementation.Views;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using Sources.Game.DataTransferObjects.Implementation.DTO.Player;
using Sources.Game.DataTransferObjects.Implementation.DTO.Settings;
using Sources.Game.DataTransferObjects.Implementation.Services;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Models
{
    public class GameplayMenuScene : IScene
    {
        private readonly IAssetService _assetService;
        private readonly ISaveLoadedServices _saveLoadedServices;
        private readonly ISettingsModelProvider _settingsModelProvider;
        private readonly MainGameMenuViewFactory _gameMenuViewFactory;
        private readonly SettingsViewFactory _settingsViewFactory;
        private readonly PlayerFactory _playerFactory;
        private readonly IFormService _formServices;

        public GameplayMenuScene
        (
            IAssetService assetService,
            ISaveLoadedServices saveLoadedGameProgressServices,
            ISettingsModelProvider settingsModelProvider,
            MainGameMenuViewFactory gameMenuViewFactory,
            SettingsViewFactory settingsViewFactory,
            PlayerFactory playerFactory,
            IFormService formServices
        )
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _saveLoadedServices = saveLoadedGameProgressServices ??
                                  throw new ArgumentNullException(nameof(saveLoadedGameProgressServices));
            _settingsModelProvider = settingsModelProvider ?? throw new ArgumentNullException(nameof(settingsModelProvider));
            _gameMenuViewFactory = gameMenuViewFactory ?? throw new ArgumentNullException(nameof(gameMenuViewFactory));
            _settingsViewFactory = settingsViewFactory ?? throw new ArgumentNullException(nameof(settingsViewFactory));
            _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
            _formServices = formServices ?? throw new ArgumentNullException(nameof(formServices));
        }

        public async void Enter()
        {
            await _assetService.LoadAsync();
            Initialize();

            _formServices.ShowForm(nameof(MainGameMenuView));
        }

        public void Initialize()
        {
            PlayerDta playerDtaData = _saveLoadedServices.Load(new PlayerDta());
            Player player = _playerFactory.Create(new PlayerLiveData(playerDtaData)); //TODO : переработать 
            MainGameMenuView gameMenuView = _gameMenuViewFactory.Create(player);
            SettingsView settingsView = _settingsViewFactory.Create(_settingsModelProvider.Model);
        }

        public void Exit()
        {
            _formServices.HideFormAll();
        }
    }
    /*
     * TODO : 1  сделать класс (модель) (Shop Upgratebl)
     * TODO : 2 сделать Сериализатор для классов (Player), (Hero) и (Shop Upgratebl)
     * TODO : 3 сделать Сервис для применения апгрэйтов при этом сотавить место для интеграции рекламы
     * TODO : 4 сделать View для сцены GamePlayMenu
     * TODO : 5 Сделать логику для загрузки уравней
     */
}