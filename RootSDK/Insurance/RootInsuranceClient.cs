using RootSDK.Insurance.Services;

namespace RootSDK.Insurance
{
    public class RootInsuranceClient : IRootInsuranceClient
    {
        public RootInsuranceClient(
            IQuoteService quoteService, 
            IClaimService claimService)
        {
            Quotes = quoteService;
            Claims = claimService;
        }

        public IQuoteService Quotes { get; }
        public IClaimService Claims { get; }
    }
}