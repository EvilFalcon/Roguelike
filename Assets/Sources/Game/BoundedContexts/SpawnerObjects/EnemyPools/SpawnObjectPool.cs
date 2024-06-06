using Sources.Game.BoundedContexts.Enemies.Dragon;
using UnityEngine;
using UnityEngine.Pool;

namespace Sources.Game.BoundedContexts.SpawnerObjects.EnemyPools
{
    public abstract class SpawnObjectPool 
    {
        private readonly ObjectPool<ISpawnObject> _objectPool;

        protected SpawnObjectPool(ISpawnObjectFactory factory) =>
            _objectPool = new ObjectPool<ISpawnObject>(factory.Create);

        public void Get(Vector3 spawnPosition)
        { 
            ISpawnObject spawnObject = _objectPool.Get();
            Build(spawnObject, spawnPosition);
        }
        
        protected abstract ISpawnObject Build(ISpawnObject spawnObject, Vector3 spawnPosition);
    }
}