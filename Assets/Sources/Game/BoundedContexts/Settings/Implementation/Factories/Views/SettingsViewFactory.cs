using System;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Settings.Implementation.Controllers;
using Sources.Game.BoundedContexts.Settings.Implementation.Factories.Presenters;
using Sources.Game.BoundedContexts.Settings.Implementation.Models;
using Sources.Game.BoundedContexts.Settings.Implementation.Views;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using UniCtor.Contexts;
using UniCtor.Sources.Di.Extensions.IDependencyResolvers;

namespace Sources.Game.BoundedContexts.Settings.Implementation.Factories.Views
{
    public class SettingsViewFactory
    {
        private readonly SettingsPresenterFactory _settingsPresenterFactory;
        private readonly ISceneContext _sceneContext;
        private readonly AssetService<SettingsAssetProvider> _assetService;
        private readonly IViewService _viewService;

        public SettingsViewFactory
        (
            SettingsPresenterFactory settingsPresenterFactory,
            ISceneContext sceneContext,
            AssetService<SettingsAssetProvider> assetService,
            IViewService viewService
        )
        {
            _settingsPresenterFactory =
                settingsPresenterFactory ?? throw new ArgumentNullException(nameof(settingsPresenterFactory));
            _sceneContext = sceneContext ?? throw new ArgumentNullException(nameof(sceneContext));
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _viewService = viewService ?? throw new ArgumentNullException(nameof(viewService));
        }

        public SettingsView Create(SettingsModel model)
        {
            SettingsView view =
                _sceneContext.DependencyResolver.InstantiateComponentFromPrefab(_assetService.Provider.SettingsView);
            SettingsPresenter presenter = _settingsPresenterFactory.Create(model, view);
            view.Construct(presenter);
            
            _viewService.AddForm(view);
            _viewService.HideFormAll();
            
            return view;
        }
    }
}