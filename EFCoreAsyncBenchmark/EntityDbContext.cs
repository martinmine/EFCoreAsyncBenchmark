using EFCoreAsyncBenchmark.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAsyncBenchmark
{
    public class EntityDbContext : DbContext 
    {
        public EntityDbContext(DbContextOptions<EntityDbContext> config) : base(config)
        {

        }

        public DbSet<DbEntity> DbEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbEntity>(entity =>
            {
                entity.HasKey(x => x.Id);
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
