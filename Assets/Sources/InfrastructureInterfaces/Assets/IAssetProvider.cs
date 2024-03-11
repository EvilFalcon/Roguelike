using System.Threading.Tasks;

namespace InfrastructureInterfaces.Assets
{
    public interface IAssetProvider
    {
        Task LoadAsync();
        void Release();
    }
}