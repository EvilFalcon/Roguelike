using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sources.Game.DataTransferObjects.Implementation.DTO.Localizations
{
    public class LocalizationData
    {
        [JsonProperty(propertyName: "MainMenu")]
        public Dictionary<string, string> MainMenu { get; set; }

        [JsonProperty(propertyName: "SettingsMenu")]

        public Dictionary<string, string> SettingsMenu { get; set; }

        [JsonProperty(propertyName: "CurrentLanguage")]
        public string CurrentLanguage { get; set; }
    }
}