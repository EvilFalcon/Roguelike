using System;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Heroes.Implementation.Controllers;
using Sources.Game.BoundedContexts.Heroes.Implementation.Factories.Controllers;
using Sources.Game.BoundedContexts.Heroes.Implementation.Models;
using Sources.Game.BoundedContexts.Heroes.Implementation.View;
using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.Presenter;
using Sources.Game.BoundedContexts.ObjectComponents.HealthComponent.Implementation.View;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using Sources.Game.Common.StateMachines.Interfaces.Hendlers;
using Sources.Game.Common.StateMachines.Interfaces.Services;
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

        public Hero Create(HeroModel hero,ILateUpdateService lateUpdateHandler)
        {
            Hero view =
                _sceneContext.DependencyResolver.InstantiateComponentFromPrefab(_assetService.Provider.Player,
                    new Vector3(43, 0, 43), Quaternion.identity);

            HeroMovementView heroMovementView = view.GetComponent<HeroMovementView>();
            HeroMovementController heroMovementController = _heroMovementControllerFactory.Create(heroMovementView, hero, lateUpdateHandler);
            heroMovementController.Enabled();
            view.Construct(heroMovementView);

            HealthComponent healthComponent = view.GetComponent<HealthComponent>();
            HealthPresenter healthPresenter = new HeroHealthPresenter(healthComponent, hero);
            healthComponent.Conctruct(healthPresenter);
            healthPresenter.Enable();

            _viewService.RegisterForm(heroMovementView);

            heroMovementView.Construct(heroMovementController);

            return view;
        }
    }
}