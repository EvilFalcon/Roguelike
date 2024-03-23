using System;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Assets.Interfaces.States;
using Sources.Game.BoundedContexts.Localizations.Implementation.Models;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.View;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Views;
using Sources.Game.BoundedContexts.Players.Implementation.Factories.PlayerModelFactories;
using Sources.Game.BoundedContexts.Players.Implementation.LiveData;
using Sources.Game.BoundedContexts.Players.Implementation.Model;
using Sources.Game.BoundedContexts.Settings.Implementation.Factories.Views;
using Sources.Game.BoundedContexts.Settings.Implementation.Models;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using Sources.Game.DataTransferObjects.Implementation.DTO;
using Sources.Game.DataTransferObjects.Implementation.DTO.Localizations;
using Sources.Game.DataTransferObjects.Implementation.DTO.Player;
using Sources.Game.DataTransferObjects.Implementation.Services;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Scenes.Implementation.Models
{
    public class GameplayMenuScene : IScene
    {
        private readonly IAssetService _assetService;
        private readonly ISaveLoadedGameProgresServices _saveLoadedGameProgresServices;
        private readonly MainGameMenuViewFactory _gameMenuViewFactory;
        private readonly SettingsViewFactory _settingsViewFactory;
        private readonly PlayerFactory _playerFactory;
        private readonly IFormService _formServices;

        public GameplayMenuScene
        (
            IAssetService assetService,
            ISaveLoadedGameProgresServices saveLoadedGameProgressServices,
            MainGameMenuViewFactory gameMenuViewFactory,
            SettingsViewFactory settingsViewFactory,
            PlayerFactory playerFactory,
            IFormService formServices
        )
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _saveLoadedGameProgresServices = saveLoadedGameProgressServices ??
                                             throw new ArgumentNullException(nameof(saveLoadedGameProgressServices));
            _gameMenuViewFactory = gameMenuViewFactory ?? throw new ArgumentNullException(nameof(gameMenuViewFactory));
            _settingsViewFactory = settingsViewFactory ?? throw new ArgumentNullException(nameof(settingsViewFactory));
            _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
            _formServices = formServices ?? throw new ArgumentNullException(nameof(formServices));
        }

        public async void Enter()
        {
            await _assetService.LoadAsync();

            PlayerDta playerDtaData = _saveLoadedGameProgresServices.LoadData(new PlayerDta());
            Player player = _playerFactory.Create(new PlayerLiveData(playerDtaData)); //TODO : переработать 
            _gameMenuViewFactory.Create(player);
            // _settingsViewFactory.Create(new SettingsModel(settingsDta));
            _formServices.ShowForm(nameof(MainGameMenuView));

            // _saveLoadedServices.SaveData(new PlayerDta());
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