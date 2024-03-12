using System.Threading.Tasks;
using Sources.Game.Common.Mvp.Implementation.PlayerMovement;

namespace Sources.Game.BoundedContexts.Assets.Implementation
{
    public class PlayerAssetProvider : AssetProviderBase
    {
        public PlayerMove PlayerMove { get; private set; }

        public override async Task LoadAsync()
        {
            PlayerMove = await Load<PlayerMove>(nameof(PlayerMove));
        }
    }
}