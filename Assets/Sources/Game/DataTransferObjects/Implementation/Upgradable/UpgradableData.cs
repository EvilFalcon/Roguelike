using Newtonsoft.Json;

namespace Sources.Game.DataTransferObjects.Implementation.Upgradable
{
    public class UpgradableData
    {
        [JsonProperty(propertyName: "ConstantImprovementArmor")]
        public int[] Armor { get; set; }

        [JsonProperty(propertyName: "ConstantImprovementAttackDelay")]
        public int[] AttackDelay { get; set; }

        [JsonProperty(propertyName: "ConstantImprovementHealth")]
        public int[] Health { get; set; }

        [JsonProperty(propertyName: "ConstantImprovementAttack")]
        public int[] Attack { get; set; }
    }
}