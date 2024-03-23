using System.Threading.Tasks;
using Sources.Game.BoundedContexts.Settings.Implementation.Views;

namespace Sources.Game.BoundedContexts.Assets.Implementation
{
    public class SettingsAssetProvider : AssetProviderBase
    {
        public SettingsView SettingsView { get; private set; }

        public override async Task LoadAsync()
        {
            SettingsView = await Load<SettingsView>(nameof(SettingsView));
        }
    }
}