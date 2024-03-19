using System;
using Sources.Game.BoundedContexts.Localizations.Implementation.Models;
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

        public MainGameMenuPresenterFactory(IFormService formService, ISceneSwitcher sceneSwitcher)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _sceneSwitcher = sceneSwitcher ?? throw new ArgumentNullException(nameof(sceneSwitcher));
        }

        public MainGameMenuPresenter Create(MainGameMenuView view, Player player, LocalizationModel model) =>
            new(view, player, model, _formService, _sceneSwitcher);
    }
}