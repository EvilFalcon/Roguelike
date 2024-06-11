using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Exceptions;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Model;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Interfaces;

namespace Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Services
{
    public class UpgradableService
    {
        public void UpgradeArmorStat(string upgradeKey, UpgradeStatsModel upgradableModel, IUpgradable player) =>
            player.ArmorModifier += PerformUpgrade(upgradeKey, player, upgradableModel);

        public void UpgradeHealth(string upgradeKey, UpgradeStatsModel upgradableModel, IUpgradable player) =>
            player.Health += PerformUpgrade(upgradeKey, player, upgradableModel);

        public void UpgradeAttack(string upgradeKey, UpgradeStatsModel upgradableModel, IUpgradable player) =>
            player.AttackModifier += PerformUpgrade(upgradeKey, player, upgradableModel);

        public void UpgradeAttackDelay(string upgradeKey, UpgradeStatsModel upgradableModel, IUpgradable player) =>
            player.AttackDelay -= PerformUpgrade(upgradeKey, player, upgradableModel) / 150f;

        private int PerformUpgrade(string upgradeKey, IUpgradable player, UpgradeStatsModel upgradableModel)
        {
            int price = CalculateUpgradePrice(upgradeKey, player.UpgradeLevelStats[upgradeKey], upgradableModel);

            if (player.Money < price)
                throw new ExceptionImpossibleTransaction("not enough money");

            player.Money -= price;
            player.UpgradeLevelStats[upgradeKey] += 1;
            return upgradableModel.UpgradeStats[upgradeKey][player.UpgradeLevelStats[upgradeKey]];
        }

        private int CalculateUpgradePrice(string upgradeKey, int currentLevel, UpgradeStatsModel upgradableModel)
        {
            int nextLevel = currentLevel + 1;
            return upgradableModel.UpgradeStats[upgradeKey][nextLevel] * nextLevel;
        }
    }
}