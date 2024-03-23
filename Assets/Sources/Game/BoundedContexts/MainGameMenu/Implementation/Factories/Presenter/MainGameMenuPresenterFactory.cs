using System;
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
        private readonly IFormService _formService;
        private readonly ISceneSwitcher _sceneSwitcher;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizationService _model;

        public MainGameMenuPresenterFactory
        (
            IFormService formService,
            ISceneSwitcher sceneSwitcher,
            ILocalizationService localizationService
        )
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _sceneSwitcher = sceneSwitcher ?? throw new ArgumentNullException(nameof(sceneSwitcher));
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
        }

        public MainGameMenuPresenter Create(MainGameMenuView view, Player player) =>
            new(view, player, _localizationService.CurrentLanguage, _formService, _sceneSwitcher);
    }
}