using System.Collections.Generic;

namespace Sources.Game.BoundedContexts.Maps.Implementation.Models
{
    public class Map
    {
        public Map(float cooldownSpawnOfEnemies, int delayingEnemyLevelUp, int maximumEnemyLevel, float levelCompletionTime,
            Dictionary<string, List<string>> enemies)
        {
            CooldownSpawnOfEnemies = cooldownSpawnOfEnemies;
            DelayingEnemyLevelUp = delayingEnemyLevelUp;
            MaximumEnemyLevel = maximumEnemyLevel;
            LevelCompletionTime = levelCompletionTime;
            Enemies = enemies;
        }

        public float CooldownSpawnOfEnemies { get; }

        public int DelayingEnemyLevelUp { get; }

        public int MaximumEnemyLevel { get; }
        
        public float LevelCompletionTime { get; }

        public Dictionary<string, List<string>> Enemies { get; }
    }
}