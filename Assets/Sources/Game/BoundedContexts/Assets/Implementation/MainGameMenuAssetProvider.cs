using System.Threading.Tasks;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Views;

namespace Sources.Game.BoundedContexts.Assets.Implementation
{
    public class MainGameMenuAssetProvider : AssetProviderBase
    {
        public MainGameMenuView MainGameMenuView { get; private set; }

        public override async Task LoadAsync() =>
            MainGameMenuView = await Load<MainGameMenuView>(nameof(MainGameMenuView));
    }
}