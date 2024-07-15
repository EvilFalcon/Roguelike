using System;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Maps.Implementation.Controllers;
using Sources.Game.BoundedContexts.Maps.Implementation.Factories.Controllers;
using Sources.Game.BoundedContexts.Maps.Implementation.View;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using UniCtor.Contexts;
using UniCtor.Sources.Di.Extensions.IDependencyResolvers;

namespace Sources.Game.BoundedContexts.Maps.Implementation.Factories.Views
{
    public class GamePlayMapViewFactory
    {
        private readonly ISceneContext _sceneContext;
        private readonly AssetService<GameMapSceneViewAssetProvider> _assetService;
        private readonly GamePlayMapPresenterFactory _gamePlayMapPresenterFactory;
        private readonly IViewService _viewService;

        public GamePlayMapViewFactory
        (
            ISceneContext sceneContext,
            IViewService viewService,
            AssetService<GameMapSceneViewAssetProvider> assetService,
            GamePlayMapPresenterFactory gamePlayMapPresenterFactory
        )
        {
            _sceneContext = sceneContext ?? throw new ArgumentNullException(nameof(sceneContext));
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _gamePlayMapPresenterFactory = gamePlayMapPresenterFactory ?? throw new ArgumentNullException(nameof(gamePlayMapPresenterFactory));
            _viewService = viewService ?? throw new ArgumentNullException(nameof(viewService));
        }

        public GamePlayMapView Create()
        {
            GamePlayMapView view = _sceneContext.DependencyResolver.InstantiateComponentFromPrefab(_assetService.Provider.GamePlayMapView);
            
            GamePlayMapPresenter presenter = _gamePlayMapPresenterFactory.Create(view);
            view.Construct(presenter);
            
            _viewService.RegisterForm(view);
            return view;
        }
    }
}