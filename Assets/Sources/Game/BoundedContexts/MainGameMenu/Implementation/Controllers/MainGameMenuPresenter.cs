using System;
using System.ComponentModel;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Views;
using Sources.Game.BoundedContexts.Audio.Interfaces;
using Sources.Game.BoundedContexts.Localizations.Implementation.Models;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Views;
using Sources.Game.BoundedContexts.Players.Implementation.Model;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using Sources.Game.BoundedContexts.Settings.Implementation.Views;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using Sources.Game.IDontCno;

namespace Sources.Game.BoundedContexts.MainGameMenu.Implementation.Controllers
{
    public class MainGameMenuPresenter : IPresenter
    {
        private readonly MainGameMenuView _view;
        private readonly Player _player;
        private readonly LocalizationModel _localizationModel;
        private readonly IViewService _viewService;
        private readonly ISceneSwitcher _sceneSwitcher;
        private readonly ISoundController _audioController;

        public MainGameMenuPresenter
        (
            MainGameMenuView view,
            Player player,
            LocalizationModel localizationModel,
            IViewService viewService,
            ISceneSwitcher sceneSwitcher,
            ISoundController audioController
        )
        {
            _view = view;
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _localizationModel = localizationModel ?? throw new ArgumentNullException(nameof(localizationModel));
            _viewService = viewService ?? throw new ArgumentNullException(nameof(viewService));
            _sceneSwitcher = sceneSwitcher ?? throw new ArgumentNullException(nameof(sceneSwitcher));
            _audioController = audioController ?? throw new ArgumentNullException(nameof(audioController));
        }

        public void Enable()
        {
            _localizationModel.PropertyChanged += OnChangedLocalization;
            _player.PropertyChanged += OnChangedMoney;

            _view.SetMoney(_player.Money);
            _view.SetButtonSettingsText(_localizationModel.MainMenu["Settings"]);
            _view.SetButtonStartGameText(_localizationModel.MainMenu["Play"]);
        }
        
        public void Disable()
        {
            _player.PropertyChanged -= OnChangedMoney;
        }

        public void StartGame()
        {
            _audioController.PlaySound();
            _sceneSwitcher.Change("GameplayScene");
        }

        public void ShowSettings()
        {
            _audioController.PlaySound();
            
            _viewService.ShowForm(nameof(SettingsView));
        }

        public void ShowUpgradeStats() =>
            _viewService.ShowForm(nameof(UpgradeStatsView));

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
                _view.SetMoney(_player.Money);
        }
    }
}