using System.Threading.Tasks;
using InfrastructureInterfaces.Assets;

namespace Assets
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
