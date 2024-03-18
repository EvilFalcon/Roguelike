using System;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Localizations.Implementation.Models;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Controllers;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.Presenter;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Views;
using Sources.Game.BoundedContexts.Players.Implementation.Model;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using UniCtor.Builders;
using UniCtor.Sources.Di.Extensions.IDependencyResolvers;

namespace Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.View
{
    public class MainGameMenuViewFactory
    {
        private readonly MainGameMenuPresenterFactory _presenterFactory;
        private readonly IDependencyResolver _dependencyResolver;
        private readonly AssetService<MainGameMenuAssetProvider> _assetService;
        private readonly IFormService _formService;

        public MainGameMenuViewFactory
        (
            MainGameMenuPresenterFactory presenterFactory,
            IDependencyResolver dependencyResolver,
            AssetService<MainGameMenuAssetProvider> assetService,
            IFormService formService
        )
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
            _dependencyResolver = dependencyResolver ?? throw new ArgumentNullException(nameof(dependencyResolver));
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public MainGameMenuView Create(Player player, LocalizationModel model)
        {
            MainGameMenuView view = _dependencyResolver.InstantiateComponentFromPrefab(_assetService.Provider.MainMenuView);
            MainGameMenuPresenter presenter = _presenterFactory.Create(view, player, model, _formService);
            _formService.AddForm(view);
            presenter.Enable();

            return view;
        }
    }
}