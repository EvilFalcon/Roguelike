using System;
using Sources.Game.BoundedContexts.Audio.Interfaces;
using Sources.Game.BoundedContexts.Localizations.Interface;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Controllers;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Views;
using Sources.Game.BoundedContexts.Players.Implementation.Model;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;

namespace Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.Presenter
{
    public class MainGameMenuPresenterFactory
    {
        private readonly IViewService _viewService;
        private readonly ISceneSwitcher _sceneSwitcher;
        private readonly ILocalizationService _localizationService;
        private readonly ISoundController _soundController;
        private readonly ISoundController _audioController;
        private readonly ILocalizationService _model;

        public MainGameMenuPresenterFactory
        (
            IViewService viewService,
            ISceneSwitcher sceneSwitcher,
            ILocalizationService localizationService,
            ISoundController soundController
        )
        {
            _viewService = viewService ?? throw new ArgumentNullException(nameof(viewService));
            _sceneSwitcher = sceneSwitcher ?? throw new ArgumentNullException(nameof(sceneSwitcher));
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
            _soundController = soundController ?? throw new ArgumentNullException(nameof(soundController));
        }

        public MainGameMenuPresenter Create(MainGameMenuView view, Player player) =>
            new(view, player, _localizationService.Localization, _viewService, _sceneSwitcher, _soundController);
    }
}