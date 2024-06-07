using System;
using System.Collections.Generic;
using Sources.Game.BoundedContexts.Heroes.Interfaces.View;
using Sources.Game.BoundedContexts.SpawnerObjects.Implementation.Stategy;
using Sources.Game.BoundedContexts.SpawnerObjects.interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sources.Game.BoundedContexts.SpawnerObjects.Implementation.View
{
    public class SpawnerObject
    {
        private const float Tangent60Degrees = 1.73905f;
        private const float Delta = 3;
        private Camera _camera;
        private Vector2 _minValue = new Vector2(15, 15);
        private Vector2 _maxValue = new Vector2(85, 85);
        private IHeroTransform _transform;
        private Dictionary<Type, SpawnObjectPool[]> _enemyPools;

        public SpawnerObject(IHeroTransform transform, Dictionary<Type, SpawnObjectPool[]> enemyPools)
        {
            _enemyPools = enemyPools;
            _camera = Camera.main;
            _transform = transform;
        }

        public void Spawn(Type key, int count)
        {
            if (_enemyPools.TryGetValue(key, out var pol) == false)
                return;

            for (int i = 0; i < count; i++)
                pol[Random.Range(0, pol.Length)].Get(GetSpawnPosition());
        }

        private Vector3 GetSpawnPosition()
        {
            float high = _camera.transform.position.y;
            float radius = high * Tangent60Degrees + Delta;

            float x = Random.Range(_minValue.x, _maxValue.x);

            IRandomStrategy
                randomStrategy = GetRandomStrategy(x, _transform.Transform.position.x, radius);
            float z = randomStrategy.GetRandomZValue(_transform.Transform.position.z, radius);

            return new Vector3(x, 0, z);
        }

        private IRandomStrategy GetRandomStrategy(float x, float transformX, float radius)
        {
            if (x < transformX + radius == false || x > transformX - radius == false)
                return new AnyZValueStrategy(_minValue.y, _maxValue.y);
            if (_transform.Transform.position.z - radius < _minValue.y)
                return new LowerZValueStrategy(_maxValue.y);
            if (_transform.Transform.position.z + radius > _maxValue.y)
                return new HigherZValueStrategy(_minValue.y);

            return Random.Range(0, 2) == 0 ? new LowerZValueStrategy(_maxValue.y) : new HigherZValueStrategy(_minValue.y);
        }
    }
}