using Sources.Game.BoundedContexts.SpawnerObjects.interfaces;
using UnityEngine;

namespace Sources.Game.BoundedContexts.Enemies.Implementation.View.Dragon
{
    public interface IEnemy 
    {
        GameObject GameObject { get; }
        void Construct(Vector3 spawnPosition);
    }
}