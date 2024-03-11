using System.Threading.Tasks;
using Presentation.PlayerMovementView;

namespace Assets
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