using Newtonsoft.Json;

namespace Sources.Game.DataTransferObjects.Implementation.Upgradable
{
    public class UpgradableData
    {
        public UpgradableData()
        {
            Armor = new[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            AttackDelay = new[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            Health = new[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            Attack = new[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        }

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