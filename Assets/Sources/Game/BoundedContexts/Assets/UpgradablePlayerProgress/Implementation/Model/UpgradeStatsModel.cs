using System.Collections.Generic;
using Sources.Game.Common.Mvp.Implementation.Model;
using Sources.Game.DataTransferObjects.Implementation.Upgradable;

namespace Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Model
{
    public class UpgradeStatsModel : ObservableModel
    {
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

        public IReadOnlyDictionary<string, int[]> UpgradeStats { get; set; }
    }
}