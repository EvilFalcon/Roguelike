using System;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Heroes.Implementation.Controllers;
using Sources.Game.BoundedContexts.Heroes.Implementation.Factories.Controllers;
using Sources.Game.BoundedContexts.Heroes.Implementation.Models;
using Sources.Game.BoundedContexts.Heroes.Implementation.View.HeroMovementView;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using UniCtor.Contexts;
using UniCtor.Sources.Di.Extensions.IDependencyResolvers;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Heroes.Implementation.Factories.Views
{
    public class HeroViewFactory
    {
        private readonly AssetService<HeroAssetProvider> _assetService;
        private readonly IViewService _viewService;
        private readonly ISceneContext _sceneContext;
        private readonly HeroMovementControllerFactory _heroMovementControllerFactory;

        public HeroViewFactory
        (
            IViewService viewService,
            ISceneContext sceneContext,
            HeroMovementControllerFactory heroMovementControllerFactory,
            AssetService<HeroAssetProvider> assetService
        )
        {
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _viewService = viewService ?? throw new ArgumentNullException(nameof(viewService));
            _sceneContext = sceneContext ?? throw new ArgumentNullException(nameof(sceneContext));
            _heroMovementControllerFactory = heroMovementControllerFactory ??
                                             throw new ArgumentNullException(nameof(heroMovementControllerFactory));
        }

        public HeroMovementView Create(HeroModel hero)
        {
            HeroMovementView view =
                _sceneContext.DependencyResolver.InstantiateComponentFromPrefab(_assetService.Provider.Player,
                    new Vector3(43, 0, 43), Quaternion.identity);

            HeroMovementController heroMovementController = _heroMovementControllerFactory.Create(view, hero);

            _viewService.AddForm(view);

            view.Construct(heroMovementController);

            return view;
        }
    }
}