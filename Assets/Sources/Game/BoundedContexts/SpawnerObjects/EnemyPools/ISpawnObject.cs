using Sources.Game.BoundedContexts.Heroes.Interfaces.View;
using UnityEngine;

namespace Sources.Game.BoundedContexts.SpawnerObjects.EnemyPools
{
    public interface ISpawnObject
    {
        void Construct(Vector3 initPosition);
        GameObject GameObject { get; }
        void Enable();
        void Disable();
    }
}