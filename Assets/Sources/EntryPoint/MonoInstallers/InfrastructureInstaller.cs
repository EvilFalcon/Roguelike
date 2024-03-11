using Assets;
using Services.InputServices;
using UniCtor.Installers;
using UniCtor.Services;

namespace MonoInstallers
{
    public class InfrastructureInstaller : MonoInstaller
    {
        public override void OnConfigure(IServiceCollection services)
        {
            services
                .RegisterAsSingleton<IInputService, StandaloneInputService>()
                .RegisterAsScoped<IAssetService>
                (
                    serviceProvider =>
                        new CompositeAssetService
                        (
                            serviceProvider.GetService<AssetService<PlayerAssetProvider>>()
                        )
                )
                ;
        }
    }
}