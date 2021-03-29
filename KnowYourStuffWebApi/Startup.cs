using KnowYourStuffCore.Interfaces;
using KnowYourStuffMongoDbConnector.DataAccess;
using KnowYourStuffSqlConnector;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace KnowYourStuffWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Set up MsSql connection
            // var connectionStringBuilder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("KnowYourStuffConnection"))
            // {
            //     DataSource = Configuration["DbCredential:Source"], UserID = Configuration["DbCredential:User"], Password = Configuration["DbCredential:Password"], InitialCatalog = "KnowYourStuff"
            // };
            // services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionStringBuilder.ConnectionString));
            // services.AddScoped<IPlatformRepository, SqlPlatformRepository>();
            
            // Set up MongoDb connection
            services.Configure<MongoDbSettings>(
                Configuration.GetSection(nameof(MongoDbSettings)));
            services.AddSingleton<IMongoDbSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            services.AddScoped<IPlatformRepository, MongoPlatformRepository>();
            
            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KnowYourStuffWebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KnowYourStuffWebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
