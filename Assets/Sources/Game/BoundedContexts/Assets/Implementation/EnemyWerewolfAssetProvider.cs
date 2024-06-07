using System.Threading.Tasks;
using Sources.Game.BoundedContexts.Enemies.Implementation.View.Werewolf;

namespace Sources.Game.BoundedContexts.Assets.Implementation
{
    public class EnemyWerewolfAssetProvider : AssetProviderBase
    {
        public WerewolfView Werewolf { get; private set; }

        public override async Task LoadAsync()
        {
            Werewolf = await Load<WerewolfView>(nameof(WerewolfView));
        }
    }
}