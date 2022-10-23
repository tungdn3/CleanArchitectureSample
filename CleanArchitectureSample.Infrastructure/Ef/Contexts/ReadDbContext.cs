using CleanArchitectureSample.Infrastructure.Ef.Configs;
using CleanArchitectureSample.Infrastructure.Ef.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Infrastructure.Ef.Contexts
{
    internal sealed class ReadDbContext : DbContext
    {
        public ReadDbContext(DbContextOptions<ReadDbContext> options)
            : base(options)
        {
        }

        public DbSet<PackingListReadModel> PackingLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("packing");

            var configuration = new ReadConfiguration();
            modelBuilder.ApplyConfiguration<PackingItemReadModel>(configuration);
            modelBuilder.ApplyConfiguration<PackingListReadModel>(configuration);
        }
    }
}
