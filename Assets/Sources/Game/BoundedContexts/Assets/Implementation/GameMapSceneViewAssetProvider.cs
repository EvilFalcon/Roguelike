using System.Threading.Tasks;
using Sources.Game.BoundedContexts.Maps.Implementation.View;

namespace Sources.Game.BoundedContexts.Assets.Implementation
{
    public class GameMapSceneViewAssetProvider : AssetProviderBase
    {
        public GamePlayMapView GamePlayMapView { get; private set; }
        
        public override async Task LoadAsync()
        {
            GamePlayMapView = await Load<GamePlayMapView>(nameof(GamePlayMapView));
        }
    }
}