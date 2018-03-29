using System.Threading.Tasks;

namespace RootSDK.Core
{
    public interface IRootApiClient
    {
        Task<T> PostAsync<T>(string url, object data, string apiArea = null);
        Task<T> GetAsync<T>(string url, string apiArea = null);
        Task<T> PutAsync<T>(string url, object data, string apiArea = null);
        void SetApiArea(string area);
    }
}