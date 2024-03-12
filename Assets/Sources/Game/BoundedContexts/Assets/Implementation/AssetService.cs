using System.Threading.Tasks;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsProviders;
using Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices;

namespace Sources.Game.BoundedContexts.Assets.Implementation
{
    public class AssetService<T> : IAssetService where T : IAssetProvider, new()
    {
        public T Provider { get; } = new T();

        public async Task LoadAsync() =>
            await Provider.LoadAsync();

        public void Release() =>
            Provider.Release();
    }
}
