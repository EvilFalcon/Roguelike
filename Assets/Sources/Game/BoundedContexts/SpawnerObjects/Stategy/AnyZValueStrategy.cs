using Sources.Game.BoundedContexts.SpawnerObjects.interfaces;
using UnityEngine;

namespace Sources.Game.BoundedContexts.SpawnerObjects.Stategy
{
    class AnyZValueStrategy : IRandomStrategy
    {
        private readonly float _min;
        private readonly float _max;

        public AnyZValueStrategy(float min, float max)
        {
            _min = min;
            _max = max;
        }

        public float GetRandomZValue(float transformZ, float radius)
        {
            return Random.Range(_min, _max);
        }
    }
}