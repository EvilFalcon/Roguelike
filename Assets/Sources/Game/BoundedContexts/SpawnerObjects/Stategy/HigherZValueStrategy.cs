using Sources.Game.BoundedContexts.SpawnerObjects.interfaces;
using UnityEngine;

namespace Sources.Game.BoundedContexts.SpawnerObjects.Stategy
{
    class HigherZValueStrategy : IRandomStrategy
    {
        private readonly float _minValue;

        public HigherZValueStrategy(float minValue)
        {
            _minValue = minValue;
        }

        public float GetRandomZValue(float transformZ, float radius)
        {
            return Random.Range(_minValue, transformZ - radius);
        }
    }
}