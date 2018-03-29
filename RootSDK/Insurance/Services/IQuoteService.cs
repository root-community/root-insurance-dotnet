using System.Collections.Generic;
using System.Threading.Tasks;
using RootSDK.Insurance.Models;

namespace RootSDK.Insurance.Services
{
    public interface IQuoteService
    {
        Task<QuoteItem<T>> CreateQuote<T>(object opts)
            where T : class, IInsurable;

        Task<IList<Gadget>> ListGadgetModels();
        Task<QuoteItem<Gadget>> CreateGadgetQuote(object opts);
        Task<QuoteItem<Term>> CreateTermQuote(object opts);
        Task<QuoteItem<Funeral>> CreateFuneralQuote(object opts);
    }
}