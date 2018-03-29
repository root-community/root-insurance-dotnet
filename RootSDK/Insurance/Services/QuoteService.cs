using System.Collections.Generic;
using System.Threading.Tasks;
using RootSDK.Core;
using RootSDK.Insurance.Models;

namespace RootSDK.Insurance.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IRootApiClient _root;

        public QuoteService(IRootApiClient root)
        {
            _root = root;
            _root.SetApiArea(RootApiAreas.Insurance);
        }

        public async Task<QuoteItem<T>> CreateQuote<T>(object opts) where T : class, IInsurable
        {
            return await _root.PostAsync<QuoteItem<T>>("quotes", opts);
        }

        public async Task<QuoteItem<Gadget>> CreateGadgetQuote(object opts)
        {
            return await _root.PostAsync<QuoteItem<Gadget>>("quotes", opts);
        }

        public async Task<QuoteItem<Term>> CreateTermQuote(object opts)
        {
            return await _root.PostAsync<QuoteItem<Term>>("quotes", opts);
        }

        public async Task<QuoteItem<Funeral>> CreateFuneralQuote(object opts)
        {
            return await _root.PostAsync<QuoteItem<Funeral>>("quotes", opts);
        }

        public async Task<IList<Gadget>> ListGadgetModels()
        {
            return await _root.GetAsync<IList<Gadget>>("modules/root_gadgets/models");
        }
    }
}