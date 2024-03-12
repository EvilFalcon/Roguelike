using System.Threading.Tasks;

namespace Sources.Game.BoundedContexts.Assets.Interfaces.AssetsProviders
{
    public interface IAssetProvider
    {
        Task LoadAsync();
        void Release();
    }
}