using Sources.Extensions.IServiceCollections;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Services;
using Sources.Game.BoundedContexts.Audio.Implementation;
using Sources.Game.BoundedContexts.Audio.Implementation.View;
using Sources.Game.BoundedContexts.Audio.Interfaces;
using Sources.Game.BoundedContexts.Inputs.Implementation.InputServices;
using Sources.Game.BoundedContexts.Inputs.Interfaces.InputServices;
using Sources.Game.BoundedContexts.Localizations.Implementation.Services;
using Sources.Game.BoundedContexts.Localizations.Interface;
using Sources.Game.BoundedContexts.Maperis.Implementation.Settings;
using Sources.Game.BoundedContexts.Maperis.Interfaces;
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
                .RegisterAsSingleton<ISettingsModelProvider, SettingsProvider>()
                .RegisterAsSingleton(FindObjectOfType<AudioView>())
                .RegisterAsSingleton<ISaveLoadedServices, ILoadDataFiles, SaveLoadedService>()
                .RegisterAsSingleton<IAudioController, IMusicController, ISoundController, AudioController>()
                .RegisterAsSingleton<ISceneFactoryProvider, SceneFactoryCollection>()
                .RegisterAsSingleton<UpgradableService>()

                .RegisterAsSingleton<ISceneConstructor, ISceneSwitcher, SceneConstructor>()
                .RegisterAsSingleton<ILoaderLocalizationService, ILocalizationService, LocalizationService>()
                .RegisterAsScoped<IFormService, FormServices>();

        }
    }
}