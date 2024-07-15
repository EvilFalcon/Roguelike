using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sources.Game.BoundedContexts.Enemies.Implementation.View.Boses;
using Sources.Game.BoundedContexts.Enemies.Implementation.View.Dragon;
using UnityEngine.Experimental.GlobalIllumination;

namespace Sources.Game.DataTransferObjects.Implementation.DTO.Enemyes
{
    [Serializable]
    public class EnemyCollectData
    {
        [JsonProperty(propertyName: "EnemiesBase")]
        public Dictionary<string, EnemyData> Enemies => new Dictionary<string, EnemyData>
        {
            { nameof(DragonFire), new EnemyData() }
        };

        [JsonProperty(propertyName: "EnemiesBoss")]
        public Dictionary<string, EnemyData> EnemiesBoss => new Dictionary<string, EnemyData>
        {
            { nameof(Werewolf), new EnemyData() }
        };
    }
}

