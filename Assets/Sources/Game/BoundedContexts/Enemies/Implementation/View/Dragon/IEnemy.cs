using UnityEngine;

namespace Sources.Game.BoundedContexts.Enemies.Implementation.View.Dragon
{
    public interface IEnemy 
    {
        
        void Enable();
        void Construct(Vector3 spawnPosition);
    }
}