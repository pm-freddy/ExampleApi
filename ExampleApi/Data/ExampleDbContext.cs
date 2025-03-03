using ExampleApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Data
{
    // Note: Class needed for code first database creation. Migration is missing cause no valid database/db connection string
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options)
        {
        }

        public DbSet<ExampleEntity> Examples { get; set; }

        public DbSet<ExampleConnectedEntity> ExamplesConnected { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ExampleConnectedEntity>()
                .HasOne(hasOne => hasOne.ExampleEntity)
                .WithMany(withMany => withMany.ConnectedEntities)
                .HasForeignKey(key => key.ExampleEntityId);
        }
    }
}
