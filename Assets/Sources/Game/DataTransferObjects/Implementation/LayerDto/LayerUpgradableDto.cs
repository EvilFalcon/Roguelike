using System.Collections.Generic;

namespace Sources.Game.DataTransferObjects.Implementation.LayerDto
{
    public class LayerUpgradableDto
    {
        public List<int> DamageModifier { get; set; }
        public List<int> AttackModifier { get; set; }
        public List<int> AttackDelay { get; set; }
        public List<int> HealthModifier { get; set; }
    }
}