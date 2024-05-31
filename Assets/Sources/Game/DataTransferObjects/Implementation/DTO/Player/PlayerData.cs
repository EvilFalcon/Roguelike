using System.Collections.Generic;
using Newtonsoft.Json;
using Sources.Game.DataTransferObjects.Interfaces;

namespace Sources.Game.DataTransferObjects.Implementation.DTO.Player
{
    public class PlayerData : IDataFiels
    {
        [JsonProperty(propertyName: "Money")] 
        public int Money { get; set; }

        [JsonProperty(propertyName: "GameProgress")]
        public int GameProgress { get; set; }

        [JsonProperty(propertyName: "Health")] 
        public int Health { get; set; }

        [JsonProperty(propertyName: "AttackDelay")]
        public float AttackDelay { get; set; }

        [JsonProperty(propertyName: "Armor")]
        public int ArmorModifier { get; set; }

        [JsonProperty(propertyName: "UpgradeStats")]
        public Dictionary<string, int> UpgradeStats { get; set; }

        [JsonProperty(propertyName: "Attack")]
        public int AttackModifier { get; set; }
        
        [JsonProperty(propertyName: "Speed")]
        public float Speed { get; set; }
    }
}