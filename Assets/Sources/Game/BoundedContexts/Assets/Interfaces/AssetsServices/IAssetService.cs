using System.Threading.Tasks;

namespace Sources.Game.BoundedContexts.Assets.Interfaces.AssetsServices
{
    public interface IAssetService
    {
        Task LoadAsync();

        void Release();
    }
}