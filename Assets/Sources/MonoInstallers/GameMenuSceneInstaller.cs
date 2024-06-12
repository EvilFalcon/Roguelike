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
                .RegisterAsScoped<AssetService<MainGameMenuAssetProvider>>()
                .RegisterAsScoped<AssetService<SettingsAssetProvider>>()
                .RegisterAsScoped<AssetService<UpgradeStatsAssetProvider>>()
                .RegisterAsScoped<IAssetService>
                (
                    serviceProvider =>
                        new CompositeAssetService
                        (
                            serviceProvider.GetService<AssetService<MainGameMenuAssetProvider>>(),
                            serviceProvider.GetService<AssetService<SettingsAssetProvider>>(),
                            serviceProvider.GetService<AssetService<UpgradeStatsAssetProvider>>()
                        )
                )
                ;
        }
    }
}