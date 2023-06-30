
using API.Options;
using Application.Services;
using Domain.Context;
using Domain.Abstractions;
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

            

            //Add Domain Contexts

            services.AddTransient<IGameContext, GameContext>();

            //Add Application Services 

            services.AddTransient<IGameService, GameService>();

            services.AddHttpClient();
            services.AddDaprClient(services => services.Build());

           

            return services;
        }
    }
}
