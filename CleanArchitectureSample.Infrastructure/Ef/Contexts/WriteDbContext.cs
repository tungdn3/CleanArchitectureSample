using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.ValueObjects;
using CleanArchitectureSample.Infrastructure.Ef.Configs;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Infrastructure.Ef.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options)
            : base(options)
        {
        }

        public DbSet<PackingList> PackingLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("packing");

            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<PackingItem>(configuration);
            modelBuilder.ApplyConfiguration<PackingList>(configuration);
        }
    }
}
