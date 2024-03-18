using Sources.Game.BoundedContexts.Localizations.Implementation.Models;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Controllers;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Views;
using Sources.Game.BoundedContexts.Players.Implementation.Model;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;

namespace Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.Presenter
{
    public class MainGameMenuPresenterFactory
    {
        public MainGameMenuPresenter Create(MainGameMenuView view, Player player, LocalizationModel model,
            IFormService formService) => new(view, player, model, formService);
    }
}