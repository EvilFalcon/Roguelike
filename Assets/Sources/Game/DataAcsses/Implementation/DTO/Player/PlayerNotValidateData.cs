using Newtonsoft.Json;

namespace Sources.Game.BoundedContexts.DTO
{
    public class PlayerNotValidateData
    {
        [JsonProperty(propertyName: "Money")] public int Money { get; set; }

        [JsonProperty(propertyName: "GameProgres")]
        public int GameProgres { get; set; }
    }
}