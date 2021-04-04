using KnowYourStuffSqlConnector.DbModels;
using Microsoft.EntityFrameworkCore;

namespace KnowYourStuffSqlConnector
{
    public class RepositoryContext : DbContext 
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
            
        }
        
        public DbSet<PlatformDbModel> Platforms { get; set; }
        public DbSet<TipDbModel> Tips { get; set; }
    }
}
