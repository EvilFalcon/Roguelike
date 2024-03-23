using System;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Controllers;
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
        private readonly IFormService _formService;

        public SettingsViewFactory(SettingsPresenterFactory settingsPresenterFactory, ISceneContext sceneContext,AssetService<SettingsAssetProvider> assetService, IFormService formService)
        {
            _settingsPresenterFactory = settingsPresenterFactory ?? throw new ArgumentNullException(nameof(settingsPresenterFactory));
            _sceneContext = sceneContext ?? throw new ArgumentNullException(nameof(sceneContext));
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public SettingsView Create(SettingsModel model)
        {
            SettingsView view = _sceneContext.DependencyResolver.InstantiateComponentFromPrefab(_assetService.Provider.SettingsView);
            SettingsPresenter presenter = _settingsPresenterFactory.Create(model, view);
            _formService.AddForm(view);
            _formService.HideForm(nameof(SettingsView));
            presenter.Enable();

            return view;
        }
    }
}