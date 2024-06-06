using System.Threading.Tasks;
using Sources.Game.BoundedContexts.Enemies.View.Dragon;

namespace Sources.Game.BoundedContexts.Assets.Implementation
{
    public class EnemyDragonAssetProvider : AssetProviderBase
    {
        public DragonView DragonView { get; private set; }

        public override async Task LoadAsync() =>
            DragonView = await Load<DragonView>(nameof(DragonView));
    }
}