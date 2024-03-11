using System.Threading.Tasks;

namespace Assets
{
    public interface IAssetService
    {
        Task LoadAsync();

        void Release();
    }
}