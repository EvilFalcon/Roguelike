using System;
using Sources.Game.BoundedContexts.Enemies.Dragon;
using Sources.Game.BoundedContexts.Heroes.Interfaces.View;
using Sources.Game.BoundedContexts.ObjectComponents.FollowComponent;
using Sources.Game.BoundedContexts.ObjectComponents.Presenters;
using UnityEngine;

namespace Sources.Game.BoundedContexts.SpawnerObjects.EnemyPools
{
    public class EnemyPool : SpawnObjectPool
    {
        private readonly IHeroTransform _transform;

        public EnemyPool(ISpawnObjectFactory factory, IHeroTransform transform) : base(factory)
        {
            _transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }

        protected override ISpawnObject Build(ISpawnObject spawnObject, Vector3 spawnPosition)
        {
            spawnObject.Construct(spawnPosition);
            EnemyFollowComponent followComponent = spawnObject.GameObject.GetComponent<EnemyFollowComponent>();
            EnemyFollowController followController = new EnemyFollowController(followComponent, _transform);
            followController.Enable();
            return spawnObject;
        }
    }
}