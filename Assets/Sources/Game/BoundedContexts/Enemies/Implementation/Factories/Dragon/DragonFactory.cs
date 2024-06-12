using System;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Enemies.Implementation.View;
using Sources.Game.BoundedContexts.Enemies.Implementation.View.Dragon;
using Sources.Game.BoundedContexts.SpawnerObjects.interfaces;
using UniCtor.Contexts;
using UniCtor.Sources.Di.Extensions.IDependencyResolvers;

namespace Sources.Game.BoundedContexts.Enemies.Implementation.Factories.Dragon
{
    public class DragonFactory : ISpawnObjectFactory
    {
        private readonly ISceneContext _sceneContext;
        private readonly AssetService<EnemyDragonAssetProvider> _assetService;

        public DragonFactory(ISceneContext sceneContext, AssetService<EnemyDragonAssetProvider> assetService)
        {
            _sceneContext = sceneContext ?? throw new ArgumentNullException(nameof(sceneContext));
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
        }

        public ISpawnObject Create() =>
            _sceneContext.DependencyResolver.InstantiateComponentFromPrefab(_assetService.Provider.DragonFire);
    }

    public interface ISpawnObjectFactory
    {
        ISpawnObject Create();
    }
}