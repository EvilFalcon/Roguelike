using System;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Model;
using Sources.Game.DataTransferObjects.Implementation.Services;
using Sources.Game.DataTransferObjects.Implementation.Upgradable;

namespace Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Factories
{
    public class UpgradeStatsModelFactory
    {
        private readonly ISaveLoadedServices _saveLoadedServices;

        public UpgradeStatsModelFactory(ISaveLoadedServices saveLoadedServices)
        {
            _saveLoadedServices = saveLoadedServices ?? throw new ArgumentNullException(nameof(saveLoadedServices));
        }

        public UpgradeStatsModel Create() =>
            new UpgradeStatsModel(_saveLoadedServices.Load<UpgradableData>(nameof(UpgradableData)));
    }
}