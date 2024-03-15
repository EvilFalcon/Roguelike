using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Model;
using Sources.Game.BoundedContexts.Players.Implementation.Model;
using Sources.Game.DataTransferObjects.Interfaces;

namespace Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Services
{
    public class PlayerUpgradableService
    {
        private readonly IDataFiels _upgradableModel;

        public PlayerUpgradableService(PlayerUpgradableModel upgradableModel)
        {
            _upgradableModel = upgradableModel;
        }
        
        public void UpgradeArmor(Player player)
        {
            //_upgradableModel;
        }
        
        public void UpgradeAttack(Player player)
        {
           // _upgradableModel.Upgrade();
        }
        
        public void UpgradeAttackDelay(Player player)
        {
           // _upgradableModel.Upgrade();
        }
        
        public void UpgradeHealth(Player player)
        {
           // _upgradableModel.Upgrade();
        }
    }
}