using Sources.Game.BoundedContexts.Enemies.Implementation.View.Dragon;
using UnityEngine;

namespace Sources.Game.BoundedContexts.SpawnerObjects.interfaces
{
    public interface ISpawnObject : IEnemy
    {
        GameObject GameObject { get; }
    }
}