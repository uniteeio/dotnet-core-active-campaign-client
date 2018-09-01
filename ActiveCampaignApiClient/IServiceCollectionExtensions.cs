using System.Net.Http;
using ActiveCampaignApiClient.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace ActiveCampaignApiClient
{
    public static class IServiceCollectionExtensions
    {
        private const string Identifier = "ActiveCampaign";
        
        public static IServiceCollection AddActiveCampaignApiClient(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<ActiveCampaignClientOptions>(configuration.GetSection(Identifier));
            services.TryAddSingleton<HttpClient>();
            services.AddHttpClient(Identifier);
            services.TryAddTransient<IActiveCampaignApiClient>((sp) =>
            {
                var options = sp.GetService<IOptions<ActiveCampaignClientOptions>>().Value;
                var factory = sp.GetService<IHttpClientFactory>();
                return new ActiveCampaignClient(factory.CreateClient(Identifier), options);
            });

            return services;
        }
    }
}