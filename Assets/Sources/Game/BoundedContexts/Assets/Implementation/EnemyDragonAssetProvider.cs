using System.Threading.Tasks;
using Sources.Game.BoundedContexts.Enemies.Implementation.View.Dragon;

namespace Sources.Game.BoundedContexts.Assets.Implementation
{
    public class EnemyDragonAssetProvider : AssetProviderBase
    {
        public DragonFire DragonFire { get; private set; }

        public override async Task LoadAsync() =>
            DragonFire = await Load<DragonFire>(nameof(DragonFire));
    }
}