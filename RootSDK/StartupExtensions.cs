using System;
using Microsoft.Extensions.DependencyInjection;
using RootSDK.Core;
using RootSDK.Insurance;
using RootSDK.Insurance.Services;

namespace RootSDK
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddRoot(this IServiceCollection services, Action<RootOptions> options)
        {
            services.Configure(options);
            // connection & helper services internal to the sdk
            services.AddSingleton<IRootConnection, RootConnection>();
            services.AddSingleton<IRootApiClient, RootApiClient>();
            
            // individual services
            services.AddSingleton<IQuoteService, QuoteService>();
            services.AddSingleton<IClaimService, ClaimService>();
            
            //container/"grouping" services
            services.AddSingleton<IRootInsuranceClient, RootInsuranceClient>();
            //services.AddSingleton<IBankingServicesCollection, BankingServicesCollection>();
            
            // overarching service
            services.AddSingleton<IRootClient, RootClient>();
            return services;
        }
    }
}