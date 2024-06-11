using Sources.Game.BoundedContexts.Enemies.Implementation.Factories.Dragon;
using Sources.Game.BoundedContexts.Enemies.Implementation.View.Dragon;
using UnityEngine;
using UnityEngine.Pool;

namespace Sources.Game.BoundedContexts.SpawnerObjects.Implementation
{
    public abstract class SpawnObjectPool 
    {
        private readonly ObjectPool<IEnemy> _objectPool;

        protected SpawnObjectPool(ISpawnObjectFactory factory) =>
            _objectPool = new ObjectPool<IEnemy>(factory.Create);

        protected abstract IEnemy Build(IEnemy spawnObject, Vector3 spawnPosition);

        public void Get(Vector3 spawnPosition)
        { 
            IEnemy spawnObject = _objectPool.Get();
            Build(spawnObject, spawnPosition);
        }

        public void ReturnToPool(IEnemy spawnObject)
        {
            _objectPool.Release(spawnObject);
        }
    }
}