using System.Threading.Tasks;
using Sources.Game.Common.Mvp.Implementation.PlayerMovement;

namespace Sources.Game.BoundedContexts.Assets.Implementation
{
    public class HeroAssetProvider : AssetProviderBase
    {
        public HeroMove HeroMove { get; private set; }

        public override async Task LoadAsync()
        {
            HeroMove = await Load<HeroMove>(nameof(HeroMove));
        }
    }
}