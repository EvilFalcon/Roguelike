using System.Threading.Tasks;
using Sources.Game.BoundedContexts.Enemies.Implementation.View.Boses;

namespace Sources.Game.BoundedContexts.Assets.Implementation
{
    public class EnemyWerewolfAssetProvider : AssetProviderBase
    {
        public Werewolf Werewolf { get; private set; }

        public override async Task LoadAsync()
        {
            Werewolf = await Load<Werewolf>(nameof(Enemies.Implementation.View.Boses.Werewolf));
        }
    }
}