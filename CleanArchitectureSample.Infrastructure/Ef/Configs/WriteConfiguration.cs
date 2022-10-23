using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitectureSample.Infrastructure.Ef.Configs
{
    internal sealed class WriteConfiguration
        : IEntityTypeConfiguration<PackingList>, IEntityTypeConfiguration<PackingItem>
    {
        public void Configure(EntityTypeBuilder<PackingItem> builder)
        {
            builder.Property<Guid>("Id");
            builder.Property(x => x.Name);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.IsPacked);
            builder.ToTable("PackingItems");
        }

        public void Configure(EntityTypeBuilder<PackingList> builder)
        {
            builder.HasKey(x => x.Id);

            var localizationConverter = new ValueConverter<Localization, string>(
                x => x.ToString(),
                x => Localization.Create(x));

            var packingListNameConverter = new ValueConverter<PackingListName, string>(
                x => x.Value,
                x => new PackingListName(x));

            builder
                .Property(x => x.Id)
                .HasConversion(
                    x => x.Value,
                    x => new PackingListId(x));

            builder
                .Property(typeof(Localization), "_localization")
                .HasConversion(localizationConverter)
                .HasColumnName("Localization");

            builder
                .Property(typeof(PackingListName), "_name")
                .HasConversion(packingListNameConverter)
                .HasColumnName("Name");

            builder.HasMany(typeof(PackingItem), "_items")
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("PackingLists");
        }
    }
}
