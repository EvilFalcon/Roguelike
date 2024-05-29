﻿using System;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Controllers;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.Presenter;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Views;
using Sources.Game.BoundedContexts.Players.Implementation.Model;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using UniCtor.Contexts;
using UniCtor.Sources.Di.Extensions.IDependencyResolvers;

namespace Sources.Game.BoundedContexts.MainGameMenu.Implementation.Factories.View
{
    public class MainGameMenuViewFactory
    {
        private readonly MainGameMenuPresenterFactory _presenterFactory;
        private readonly ISceneContext _sceneContext;
        private readonly AssetService<MainGameMenuAssetProvider> _assetService;
        private readonly IFormService _formService;

        public MainGameMenuViewFactory
        (
            MainGameMenuPresenterFactory presenterFactory,
            ISceneContext sceneContext,
            AssetService<MainGameMenuAssetProvider> assetService,
            IFormService formService
        )
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
            _sceneContext = sceneContext ?? throw new ArgumentNullException(nameof(sceneContext));
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public MainGameMenuView Create(Player player)
        {
            MainGameMenuView view =
                _sceneContext.DependencyResolver.InstantiateComponentFromPrefab(_assetService.Provider.MainGameMenuView);
            MainGameMenuPresenter presenter = _presenterFactory.Create(view, player);
            _formService.AddForm(view);

            view.Construct(presenter);

            return view;
        }
    }
}