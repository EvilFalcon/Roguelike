﻿using System;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Model;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Presenter;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Views;
using Sources.Game.BoundedContexts.Players.Interfaces;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using UniCtor.Contexts;
using UniCtor.Sources.Di.Extensions.IDependencyResolvers;

namespace Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Factories
{
    public class UpgradeStatsViewFactory
    {
        private readonly UpgradeStatsPresenterFactory _presenterFactory;
        private readonly AssetService<UpgradeStatsAssetProvider> _assetService;
        private readonly ISceneContext _sceneContext;
        private readonly IFormService _formService;

        public UpgradeStatsViewFactory
        (
            ISceneContext sceneContext,
            IFormService formService,
            UpgradeStatsPresenterFactory presenterFactory,
            AssetService<UpgradeStatsAssetProvider> assetService
        )
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _sceneContext = sceneContext ?? throw new ArgumentNullException(nameof(sceneContext));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public UpgradeStatsView Create(UpgradeStatsModel model, IPlayer player)
        {
            UpgradeStatsView view =
                _sceneContext.DependencyResolver.InstantiateComponentFromPrefab(_assetService.Provider.UpgradeStatsView);
            UpgradeStatsPresenter presenter = _presenterFactory.Create(view, model, player);
            view.Construct(presenter);
            
            _formService.AddForm(view);
            
            _formService.HideForm(nameof(UpgradeStatsView));
            return view;
        }
    }
}