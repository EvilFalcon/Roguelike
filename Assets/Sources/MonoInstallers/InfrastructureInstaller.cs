using Sources.Extensions.IServiceCollections;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Inputs.Implementation.InputServices;
using Sources.Game.BoundedContexts.Inputs.Interfaces.InputServices;
using Sources.Game.BoundedContexts.Localizations.Implementation.Services;
using Sources.Game.BoundedContexts.Localizations.Interface;
using Sources.Game.BoundedContexts.Scenes.Implementation.Factories;
using Sources.Game.BoundedContexts.Scenes.Implementation.Services;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Factories;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
using Sources.Game.BoundedContexts.Settings.Implementation.Controllers;
using Sources.Game.BoundedContexts.Settings.Interfaces;
using Sources.Game.BoundedContexts.ViewFormServices.Implementation;
using Sources.Game.BoundedContexts.ViewFormServices.Interfaces;
using Sources.Game.DataTransferObjects.Implementation.Services;
using Sources.Game.DataTransferObjects.Interfaces;
using UniCtor.Installers;
using UniCtor.Services;

namespace Sources.MonoInstallers
{
    public class InfrastructureInstaller : MonoInstaller
    {
        public override void OnConfigure(IServiceCollection services)
        {
            services
                .RegisterAsSingleton<ISceneFactoryProvider, SceneFactoryCollection>()
                .RegisterAsSingleton<ISaveLoadedGameProgresServices, DataSaveLoadedGameProgressServices>()
                .RegisterAsSingleton<IInputService, StandaloneInputService>()
                .RegisterAsSingleton<AssetService<MainGameMenuAssetProvider>>()
                .RegisterAsSingleton<AssetService<SettingsAssetProvider>>()
                .RegisterAsSingleton<AssetService<HeroAssetProvider>>()
                .RegisterAsSingleton<ISceneConstructor, ISceneSwitcher, SceneConstructor>()
                .RegisterAsSingleton<IAudioServices, AudioServices>()
                .RegisterAsSingleton<ILoaderLocalizationService, ILocalizationService, LocalizationService>()
                .RegisterAsSingleton<ISaveLoadedGameProgresServices, ILoadDataFiles, DataSaveLoadedGameProgressServices>()
                .RegisterAsScoped<IFormService, FormServices>()
                .RegisterAsScoped<IAssetService>
                (
                    serviceProvider =>
                        new CompositeAssetService
                        (
                            serviceProvider.GetService<AssetService<HeroAssetProvider>>(),
                            serviceProvider.GetService<AssetService<MainGameMenuAssetProvider>>(),
                            serviceProvider.GetService<AssetService<SettingsAssetProvider>>()
                        )
                )
                .RegisterAsScoped(serviceProvider =>
                    serviceProvider.GetService<AssetService<MainGameMenuAssetProvider>>().Provider)
                .RegisterAsScoped(serviceProvider =>
                    serviceProvider.GetService<AssetService<SettingsAssetProvider>>().Provider);
            ;
        }
    }
}