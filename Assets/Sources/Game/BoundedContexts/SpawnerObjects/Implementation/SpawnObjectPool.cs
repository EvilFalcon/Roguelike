using Sources.Game.BoundedContexts.Enemies.Implementation.Factories.Dragon;
using Sources.Game.BoundedContexts.SpawnerObjects.interfaces;
using UnityEngine;
using UnityEngine.Pool;

namespace Sources.Game.BoundedContexts.SpawnerObjects.Implementation
{
    public abstract class SpawnObjectPool 
    {
        private readonly ObjectPool<ISpawnObject> _objectPool;

        protected SpawnObjectPool(ISpawnObjectFactory factory) =>
            _objectPool = new ObjectPool<ISpawnObject>(factory.Create);

        protected abstract ISpawnObject Build(ISpawnObject spawnObject, Vector3 spawnPosition);

        public void Get(Vector3 spawnPosition)
        { 
            ISpawnObject spawnObject = _objectPool.Get();
            Build(spawnObject, spawnPosition);
        }

        public void ReturnToPool(ISpawnObject spawnObject)
        {
            _objectPool.Release(spawnObject);
        }
    }
}