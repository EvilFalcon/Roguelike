
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Exceptions;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Model;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Interfaces;

namespace Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Services
{
    public class UpgradableService
    {
        private readonly UpgradeStatsModel _upgradableModel;
        private readonly IUpgradable _player;

        public UpgradableService(UpgradeStatsModel upgradableModel, IUpgradable player)
        {
            _upgradableModel = upgradableModel;
            _player = player;
        }

        public void UpgradeArmor()
        {
            UpgradeStat("armor", _upgradableModel.CurrentArmorLevel);
            _upgradableModel.CurrentArmorLevel++;
            
        }

        public void UpgradeAttack()
        {
            UpgradeStat("attack", _upgradableModel.CurrentAttackLevel);
            _upgradableModel.CurrentAttackLevel++;
        }

        public void UpgradeAttackDelay()
        {
            UpgradeStat("attackDelay", _upgradableModel.CurrentAttackDelay);
            _upgradableModel.CurrentAttackDelay++;
        }

        public void UpgradeHealth()
        {
            UpgradeStat("health", _upgradableModel.CurrentHealthLevel);
            _upgradableModel.CurrentHealthLevel++;
        }

        private void UpgradeStat(string upgradeKey, int upgradeLevel)
        {
            int price = CalculateUpgradePrice(upgradeKey, upgradeLevel);

            if (_player.Money < price)
            {
                throw new ExceptionImpossibleTransaction("not enough money");
            }

            _player.Money -= price;
            upgradeLevel += 1;
            _player.ArmorModifier += _upgradableModel.UpgradeStats[upgradeKey][upgradeLevel];
        }

        private int CalculateUpgradePrice(string upgradeKey, int currentLevel)
        {
            int nextLevel = currentLevel + 1;
            return _upgradableModel.UpgradeStats[upgradeKey][nextLevel] * nextLevel;
        }
    }
}
