using System.Net.Http;

namespace RootSDK.Core
{
    public interface IRootConnection
    {
        HttpClient Connect();
    }
}