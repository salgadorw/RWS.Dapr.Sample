
using API.Options;
using Application.Services;
using Domain.DomainEntities;
using Domain.Contracts;
using Infrastructure.Gateway.Options;
using Infrastructure.Gateway;
using Dapr.Client;

namespace API.DI
{
    public static class ConfigureDIServices
    {
        public static IServiceCollection AddAPIGatewayDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //Add Configuration Options

            services.Configure<RequiredHeadersOptions>(         
                configuration.GetSection(nameof(RequiredHeadersOptions)));
            services.Configure<FeedGatewayOptions>(
                configuration.GetSection(nameof(FeedGatewayOptions)));
    
            //Add Feed Gateway Implementation

            services.AddTransient<IFeedGateway, FeedGateway>();

            

            //Add Domain DomainEntitiess

            services.AddTransient<IGameDE, GameDE>();

            //Add Application Services 

            services.AddTransient<IGameService, GameService>();

            services.AddHttpClient();
            services.AddDaprClient(services => services.Build()); // Replace with your Dapr HTTP port
      // Replace with your Dapr gRPC port.Build());




            return services;
        }
    }
}
