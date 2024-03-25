using Sources.Extensions.IServiceCollections;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Audio.Implementation;
using Sources.Game.BoundedContexts.Audio.Implementation.View;
using Sources.Game.BoundedContexts.Audio.Interfaces;
using Sources.Game.BoundedContexts.Inputs.Implementation.InputServices;
using Sources.Game.BoundedContexts.Inputs.Interfaces.InputServices;
using Sources.Game.BoundedContexts.Localizations.Implementation.Services;
using Sources.Game.BoundedContexts.Localizations.Interface;
using Sources.Game.BoundedContexts.Scenes.Implementation.Services;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Factories;
using Sources.Game.BoundedContexts.Scenes.Interfaces.Services;
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
                .RegisterAsSingleton(FindObjectOfType<AudioView>())
                .RegisterAsSingleton<IAudioController, IMusicController, ISoundController, AudioController>()
                .RegisterAsSingleton<ISceneFactoryProvider, SceneFactoryCollection>()
                .RegisterAsSingleton<ISaveLoadedGameProgresServices, DataSaveLoadedGameProgressServices>()
                .RegisterAsSingleton<IInputService, StandaloneInputService>() /* TODO: вынести в отдельный модуль*/
                .RegisterAsSingleton<AssetService<MainGameMenuAssetProvider>>()
                .RegisterAsSingleton<AssetService<SettingsAssetProvider>>()
                .RegisterAsSingleton<AssetService<HeroAssetProvider>>() /* TODO: вынести в отдельный модуль*/
                .RegisterAsSingleton<ISceneConstructor, ISceneSwitcher, SceneConstructor>()
                .RegisterAsSingleton<ILoaderLocalizationService, ILocalizationService, LocalizationService>()
                .RegisterAsSingleton<ISaveLoadedGameProgresServices, ILoadDataFiles, DataSaveLoadedGameProgressServices>()
                .RegisterAsScoped<IFormService, FormServices>()
                .RegisterAsScoped<IAssetService>
                (
                    serviceProvider =>
                        new CompositeAssetService
                        (
                            serviceProvider.GetService<AssetService<AssetProviderAudioView>>()
                        )
                )
                .RegisterAsSingleton(serviceProvider =>
                    serviceProvider.GetService<AssetService<AssetProviderAudioView>>().Provider)
                ;
        }
    }
}