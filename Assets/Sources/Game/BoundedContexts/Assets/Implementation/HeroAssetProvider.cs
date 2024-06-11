using System.Threading.Tasks;
using Sources.Game.BoundedContexts.Heroes.Implementation.View;

namespace Sources.Game.BoundedContexts.Assets.Implementation
{
    public class HeroAssetProvider : AssetProviderBase
    {
        public Hero Player { get; private set; }

        public override async Task LoadAsync()
        {
            Player = await Load<Hero>(nameof(Player));
        }
    }
}