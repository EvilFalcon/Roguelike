using Newtonsoft.Json;
using Sources.Game.DataTransferObjects.Interfaces;

namespace Sources.Game.DataTransferObjects.Implementation.DTO.Player
{
    public class PlayerDta : IDataFiels
    {
        [JsonProperty(propertyName: "Money")] public int Money { get; set; }

        [JsonProperty(propertyName: "GameProgres")]
        public int GameProgres { get; set; }

        [JsonProperty(propertyName: "Health")] public int Health { get; set; }

        [JsonProperty(propertyName: "AttackDelay")]
        public int AttackDelay { get; set; }

        [JsonProperty(propertyName: "ArmorModifier")]
        public int ArmorModifier { get; set; }

        [JsonProperty(propertyName: "AttackModifier")]
        public int AttackModifier { get; set; }
    }
}