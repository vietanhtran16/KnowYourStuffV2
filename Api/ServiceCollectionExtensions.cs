using Infrastructure.MongoDbRepository;
using Infrastructure.MongoDbRepository.DataAccess;
using Infrastructure.MsSqlDbRepository;
using KnowYourStuffCore.Interfaces;
using KnowYourStuffCore.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace KnowYourStuffWebApi
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IPlatformService, PlatformService>();
            services.AddScoped<ITipService, TipService>();
        }

        public static void AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            switch (configuration["AppSettings:DbType"])
            {
                case "MongoDb":
                    SetUpMongoDb(services, configuration);
                    break;
                default:
                    SetUpMsSqlDb(services, configuration);
                    break;
            }
        }

        private static void SetUpMsSqlDb(IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = configuration["SqlDbSettings:Source"], UserID = configuration["SqlDbSettings:User"],
                Password = configuration["SqlDbSettings:Password"], InitialCatalog = configuration["SqlDbSettings:InitialCatalog"]
            };
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionStringBuilder.ConnectionString));
            services.AddScoped<IPlatformRepository, SqlPlatformRepository>();
            services.AddScoped<ITipRepository, SqlTipRepository>();
        }

        private static void SetUpMongoDb(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(
                configuration.GetSection(nameof(MongoDbSettings)));
            services.AddSingleton(sp =>
                sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            services.AddScoped<IPlatformRepository, MongoPlatformRepository>();
            services.AddScoped<ITipRepository, MongoTipRepository>();
        }
    }
}