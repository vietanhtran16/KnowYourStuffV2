using KnowYourStuffCore.Interfaces;
using KnowYourStuffCore.Services;
using KnowYourStuffMongoDbConnector.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace KnowYourStuffWebApi
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IPlatformService, PlatformService>();
            services.AddScoped<ITipService, TipService>();
            return services;
        }

        public static IServiceCollection AddMongoDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(
                configuration.GetSection(nameof(MongoDbSettings)));
            services.AddSingleton<IMongoDbSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            services.AddScoped<IPlatformRepository, MongoPlatformRepository>();
            services.AddScoped<ITipRepository, MongoTipRepository>();
            return services;
        }
    }
}