using Newtonsoft.Json;
using Sources.Game.DataTransferObjects.Interfaces;

namespace Sources.Game.DataTransferObjects.Implementation.DTO
{
    public class SettingsData : IDataFiels
    {
        [JsonProperty(propertyName: "LocalizationMode")] public string LocalizationMode { get; set; }

        [JsonProperty(propertyName: "SoundEffectsVolume")]
        public float SoundEffectsVolume { get; set; }

        [JsonProperty(propertyName: "MusicVolume")] public float MusicVolume { get; set; }
    }
}