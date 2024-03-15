using System.Collections.Generic;
using Sources.Game.DataTransferObjects.Implementation.LayerDto;

namespace Sources.Game.DataTransferObjects.Implementation.DTO.Upgradable
{
    public class PlayerUpgradableDto
    {
        public PlayerUpgradableDto(LayerUpgradableDto layerUpgradableDto)
        {
            DamageModifier = layerUpgradableDto.DamageModifier;
            AttackModifier = layerUpgradableDto.AttackModifier;
            AttackDelay = layerUpgradableDto.AttackDelay;
            HealthModifier = layerUpgradableDto.HealthModifier;
        }

        public List<int> DamageModifier { get; }
        public List<int> AttackModifier { get; }
        public List<int> AttackDelay { get; }
        public List<int> HealthModifier { get; }
    }
}