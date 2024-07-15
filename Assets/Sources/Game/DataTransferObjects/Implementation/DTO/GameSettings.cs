using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sources.Game.DataTransferObjects.Implementation.DTO.Enemyes;
using Sources.Game.DataTransferObjects.Implementation.DTO.Localizations;
using Sources.Game.DataTransferObjects.Implementation.DTO.Player;
using Sources.Game.DataTransferObjects.Implementation.Upgradable;

namespace Sources.Game.DataTransferObjects.Implementation.DTO
{
    [Serializable]
    public class GameSettings
    {
        public GameSettings()
        {
            GameSettingsData = new Dictionary<string, object>()
            {
                { nameof(LocalizationData), new LocalizationData() },
                { nameof(PlayerData), new PlayerData() },
                { nameof(UpgradableData), new UpgradableData() },
                { nameof(EnemyCollectData), new EnemyCollectData() },
            };
        }

        [JsonProperty(propertyName: "GameSettingsData")]
        public Dictionary<string, object> GameSettingsData { get; set; }
    }
}