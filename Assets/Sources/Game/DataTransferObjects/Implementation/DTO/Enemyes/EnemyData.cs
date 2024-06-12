using Newtonsoft.Json;

namespace Sources.Game.DataTransferObjects.Implementation.DTO.Enemyes
{
    public class EnemyData
    {
        [JsonProperty(propertyName: "Health")] public int Health { get; set; }

        [JsonProperty(propertyName: "Armor")] public int Armor { get; set; }

        [JsonProperty(propertyName: "Damage")] public int Damage { get; set; }

        [JsonProperty(propertyName: "AttackDelay")]
        public float AttackDelay { get; set; }

        [JsonProperty(propertyName: "Speed")]
        public float Speed { get; set; }

        [JsonProperty(propertyName: "Gold")]
        public int Gold { get; set; }

        [JsonProperty(propertyName: "Experience")]
        public int Experience { get; set; }

        [JsonProperty(propertyName: "HealthModifier")]
        public int HealthModifier { get; set; }

        [JsonProperty(propertyName: "ArmorModifier")]
        public int ArmorModifier { get; set; }

        [JsonProperty(propertyName: "DamageModifier")]
        public int DamageModifier { get; set; }
    }
}