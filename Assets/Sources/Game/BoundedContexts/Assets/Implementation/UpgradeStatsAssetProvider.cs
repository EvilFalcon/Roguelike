using System.Threading.Tasks;
using Sources.Game.BoundedContexts.Assets.UpgradablePlayerProgress.Implementation.Views;

namespace Sources.Game.BoundedContexts.Assets.Implementation
{
    public class UpgradeStatsAssetProvider : AssetProviderBase
    {
        public UpgradeStatsView UpgradeStatsView { get; private set; }

        public override async Task LoadAsync() =>
            UpgradeStatsView = await Load<UpgradeStatsView>(nameof(UpgradeStatsView));
    }
}