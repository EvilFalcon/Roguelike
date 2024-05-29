using System.Collections.Generic;
using Sources.Game.Common.Mvp.Implementation.Model;
using Sources.Game.DataTransferObjects.Implementation.Upgradable;

namespace Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Model
{
    public class UpgradeStatsModel : ObservableModel
    {
        private int _currentArmorLevel = 0;
        private int _currentAttackLevel = 0;
        private int _currentAttackDelay = 0;
        private int _currentHealthLevel = 0;

        public UpgradeStatsModel(UpgradableData upgradableData)
        {
            UpgradeStats = new Dictionary<string, int[]>()
            {
                { nameof(UpgradableData.Armor), upgradableData.Armor },
                { nameof(UpgradableData.AttackDelay), upgradableData.AttackDelay },
                { nameof(UpgradableData.Health), upgradableData.Health },
                { nameof(UpgradableData.Attack), upgradableData.Attack }
            };
        }

        public int CurrentArmorLevel
        {
            get => _currentArmorLevel;
            set => TrySetField(ref _currentArmorLevel, value);
        }

        public int CurrentAttackDelay
        {
            get => _currentAttackDelay;
            set => TrySetField(ref _currentAttackDelay, value);
        }

        public int CurrentAttackLevel
        {
            get => _currentAttackLevel;
            set => TrySetField(ref _currentAttackLevel, value);
        }

        public int CurrentHealthLevel
        {
            get => _currentHealthLevel;
            set => TrySetField(ref _currentHealthLevel, value);
        }

        public IReadOnlyDictionary<string, int[]> UpgradeStats { get; set; }
    }
}