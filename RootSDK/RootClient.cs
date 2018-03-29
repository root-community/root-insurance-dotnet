using RootSDK.Insurance;

namespace RootSDK
{
    public class RootClient : IRootClient
    {
        public IRootInsuranceClient  Insurance { get; }

        public RootClient(IRootInsuranceClient insurance)
        {
            Insurance = insurance;
        }
    }
}