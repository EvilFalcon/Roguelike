using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Inputs.Implementation.InputServices;
using Sources.Game.BoundedContexts.Inputs.Interfaces.InputServices;
using UniCtor.Installers;
using UniCtor.Services;

namespace Sources.MonoInstallers
{
    public class GamePlayInstaller : MonoInstaller
    {
        public override void OnConfigure(IServiceCollection services)
        {
            services
                .RegisterAsSingleton<IInputService, StandaloneInputService>()
                .RegisterAsSingleton<AssetService<HeroAssetProvider>>() 
                .RegisterAsScoped<IAssetService>
                (
                    serviceProvider =>
                        new CompositeAssetService
                        (
                            serviceProvider.GetService<AssetService<HeroAssetProvider>>()
                        )
                )
                .RegisterAsScoped(servicesProvider => servicesProvider.GetService<AssetService<HeroAssetProvider>>());
        }
    }
}