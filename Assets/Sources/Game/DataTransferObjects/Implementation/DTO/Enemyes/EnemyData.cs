using Newtonsoft.Json;

namespace Sources.Game.DataTransferObjects.Implementation.DTO.Enemyes
{
    public class EnemyData
    {
        [JsonProperty(propertyName: "Health")]
        public int Health { get; set; }
        
        [JsonProperty(propertyName: "Armor")]
        public int Armor { get; set; }
        
        [JsonProperty(propertyName: "Attack")]
        public int Attack { get; set; }

        [JsonProperty(propertyName: "AttackDelay")]
        public float AttackDelay { get; set; }

        [JsonProperty(propertyName: "Speed")] 
        public float Speed { get; set; }
    }
}