using Sources.Game.BoundedContexts.SpawnerObjects.interfaces;
using UnityEngine;

namespace Sources.Game.BoundedContexts.SpawnerObjects.Implementation.Stategy
{
    class LowerZValueStrategy : IRandomStrategy
    {
        private readonly float _maxValueZ;

        public LowerZValueStrategy(float maxValueZ)
        {
            _maxValueZ = maxValueZ;
        }

        public float GetRandomZValue(float transformZ, float radius)
        {
            return Random.Range(transformZ + radius, _maxValueZ);
        }
    }
}