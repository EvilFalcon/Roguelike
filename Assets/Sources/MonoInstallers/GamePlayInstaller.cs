using Sources.Extensions.IServiceCollections;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;
using Sources.Game.BoundedContexts.Inputs.Implementation.InputServices;
using Sources.Game.BoundedContexts.Inputs.Interfaces.InputServices;
using Sources.Game.Common.StateMachines.Interfaces.Hendlers;
using Sources.Game.Common.StateMachines.Interfaces.Services;
using Sources.Game.Common.StateMachines.Services;
using UniCtor.Installers;
using UniCtor.Services;

namespace Sources.MonoInstallers
{
    public class GamePlayInstaller : MonoInstaller
    {
        public override void OnConfigure(IServiceCollection services)
        {
            services
                .RegisterAsSingleton<IUpdateService, IUpdateHandler, UpdateService>()
                .RegisterAsSingleton<IFixedUpdateService, IFixedUpdateHandler, FixedUpdateService>()
                .RegisterAsSingleton<ILateUpdateService, ILateUpdateHandler, LateUpdateService>()
                .RegisterAsSingleton<IInputService, StandaloneInputService>()
                .RegisterAsSingleton<AssetService<EnemyWerewolfAssetProvider>>()
                .RegisterAsSingleton<AssetService<EnemyDragonAssetProvider>>()
                .RegisterAsSingleton<AssetService<HeroAssetProvider>>()
                .RegisterAsSingleton<AssetService<GameMapSceneViewAssetProvider>>()
                .RegisterAsScoped<IAssetService>
                (
                    serviceProvider =>
                        new CompositeAssetService
                        (
                            serviceProvider.GetService<AssetService<HeroAssetProvider>>(),
                            serviceProvider.GetService<AssetService<EnemyDragonAssetProvider>>(),
                            serviceProvider.GetService<AssetService<EnemyWerewolfAssetProvider>>(),
                            serviceProvider.GetService<AssetService<GameMapSceneViewAssetProvider>>()
                        )
                );
        }
    }
}