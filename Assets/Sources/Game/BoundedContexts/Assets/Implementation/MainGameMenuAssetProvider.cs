using System.Threading.Tasks;
using Sources.Game.BoundedContexts.MainGameMenu.Implementation.Views;

namespace Sources.Game.BoundedContexts.Assets.Implementation
{
    public class MainGameMenuAssetProvider : AssetProviderBase
    {
        public MainGameMenuView MainMenuView { get; private set; }

        public override async Task LoadAsync() =>
            MainMenuView = await Load<MainGameMenuView>(nameof(MainGameMenuView));
    }
}