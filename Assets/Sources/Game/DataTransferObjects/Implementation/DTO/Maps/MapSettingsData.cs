using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sources.Game.DataTransferObjects.Implementation.DTO.Enemyes
{
    public class MapSettingsData
    {
        [JsonProperty(propertyName: "Level")] public Dictionary<string, LevelData> Level { get; set; }
    }

    public class LevelData
    {
        [JsonProperty(propertyName: "CooldownSpawnOfEnemies")]
        public float CooldownSpawnOfEnemies { get; set; }

        [JsonProperty(propertyName: "DelayingEnemyLevel-up")]
        public int DelayingEnemyLevelUp { get; set; }

        [JsonProperty(propertyName: "MaximumEnemyLevel")]
        public int MaximumEnemyLevel { get; set; }
        
        [JsonProperty(propertyName: "LevelCompletionTime")]
        public float LevelCompletionTime { get; set; }

        [JsonProperty(propertyName: "Enemies")]
        public Dictionary<string, List<string>> Enemies { get; set; }
    }
}