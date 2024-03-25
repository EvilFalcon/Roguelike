using System;
using System.ComponentModel;
using Sources.Game.BoundedContexts.Localizations.Implementation.Models;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Views;
using Sources.Game.BoundedContexts.Players.Implementation.Model;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using Sources.Game.BoundedContexts.Settings.Implementation.Views;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using Sources.Game.Common.Mvp.Interfaces;

namespace Sources.Game.BoundedContexts.MainGameMenu.Implementation.Controllers
{
    public class MainGameMenuPresenter : IPresenter
    {
        private readonly MainGameMenuView _view;
        private readonly Player _player;
        private readonly LocalizationModel _localizationModel;
        private readonly IFormService _formService;
        private readonly ISceneSwitcher _sceneSwitcher;

        public MainGameMenuPresenter
        (
            MainGameMenuView view,
            Player player,
            LocalizationModel localizationModel,
            IFormService formService,
            ISceneSwitcher sceneSwitcher
        )
        {
            _view = view;
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _localizationModel = localizationModel ?? throw new ArgumentNullException(nameof(localizationModel));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _sceneSwitcher = sceneSwitcher ?? throw new ArgumentNullException(nameof(sceneSwitcher));
        }

        public void Enable()
        {
            _localizationModel.PropertyChanged += OnChangedLocalization;
            _player.PropertyChanged += OnChangedMoney;

            _player.Money = 100000;
            _view.SetButtonSettingsText(_localizationModel.MainMenu["Settings"]);
            _view.SetButtonStartGameText(_localizationModel.MainMenu["Play"]);
        }

        private void OnChangedLocalization(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LocalizationModel.Language))
            {
                _view.SetButtonSettingsText(_localizationModel.MainMenu["Settings"]);
                _view.SetButtonStartGameText(_localizationModel.MainMenu["Play"]);
            }
        }

        private void OnChangedMoney(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Player.Money))
            {
                _view.SetMoney(_player.Money);
            }
        }

        public void Disable()
        {
            _player.PropertyChanged -= OnChangedMoney;
        }

        public void StartGame()
        {
            _sceneSwitcher.Change("GameplayScene");
        }

        public void ShowSettings() =>
            _formService.ShowForm(nameof(SettingsView));
    }
}