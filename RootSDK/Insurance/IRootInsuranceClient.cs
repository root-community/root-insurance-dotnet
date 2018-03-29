using RootSDK.Insurance.Services;

namespace RootSDK.Insurance
{
    public interface IRootInsuranceClient
    {
        IQuoteService Quotes { get; }
        IClaimService Claims { get; }
    }
}