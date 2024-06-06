﻿using System;
using Sources.Game.BoundedContexts.Assets.Implementation;
using Sources.Game.BoundedContexts.Enemies.Dragon;
using Sources.Game.BoundedContexts.SpawnerObjects.EnemyPools;
using UniCtor.Contexts;
using UniCtor.Sources.Di.Extensions.IDependencyResolvers;

namespace Sources.Game.BoundedContexts.Enemies.Factories.Werewolf
{
    public class WerewolfFactory : ISpawnObjectFactory
    {
        private readonly ISceneContext _sceneContext;
        private readonly AssetService<EnemyWerewolfAssetProvider> _assetService;
        
        public WerewolfFactory(ISceneContext sceneContext, AssetService<EnemyWerewolfAssetProvider> assetService)
        {
            _sceneContext = sceneContext ?? throw new ArgumentNullException(nameof(sceneContext));
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
        }
        

        public ISpawnObject Create() =>
            _sceneContext.DependencyResolver.InstantiateComponentFromPrefab(_assetService.Provider.Werewolf);
    }
}