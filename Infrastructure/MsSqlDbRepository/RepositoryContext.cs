using Infrastructure.MsSqlDbRepository.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.MsSqlDbRepository
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
