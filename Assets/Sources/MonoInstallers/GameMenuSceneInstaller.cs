using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using UniCtor.Installers;
using UniCtor.Services;

namespace Sources.MonoInstallers
{
    public class GameMenuSceneInstaller : MonoInstaller
    {
        public override void OnConfigure(IServiceCollection services)
        {
            services
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
        }
    }
}