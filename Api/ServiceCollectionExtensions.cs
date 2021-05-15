using KnowYourStuffCore.Interfaces;
using KnowYourStuffCore.Services;
using KnowYourStuffMongoDbConnector;
using KnowYourStuffMongoDbConnector.DataAccess;
using KnowYourStuffSqlConnector;
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
        }

        private static void SetUpMongoDb(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(
                configuration.GetSection(nameof(MongoDbSettings)));
            services.AddSingleton(sp =>
                sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            services.AddScoped<IPlatformRepository, MongoPlatformRepository>();
        }
    }
}