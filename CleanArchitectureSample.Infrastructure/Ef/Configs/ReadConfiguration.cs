using CleanArchitectureSample.Infrastructure.Ef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureSample.Infrastructure.Ef.Configs
{
    internal sealed class ReadConfiguration
        : IEntityTypeConfiguration<PackingListReadModel>, IEntityTypeConfiguration<PackingItemReadModel>
    {
        public void Configure(EntityTypeBuilder<PackingListReadModel> builder)
        {
            builder.ToTable("PackingLists");
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Localization)
                .HasConversion(x => x.ToString(), x => LocalizationReadModel.Create(x));
        }

        public void Configure(EntityTypeBuilder<PackingItemReadModel> builder)
        {
            builder.ToTable("PackingItems");
        }
    }
}
