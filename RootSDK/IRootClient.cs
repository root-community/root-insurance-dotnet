using RootSDK.Insurance;

namespace RootSDK
{   
    public interface IRootClient
    {
        IRootInsuranceClient  Insurance { get; }
    }
}