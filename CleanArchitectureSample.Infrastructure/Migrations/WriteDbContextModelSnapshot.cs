// <auto-generated />
using System;
using CleanArchitectureSample.Infrastructure.Ef.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CleanArchitectureSample.Infrastructure.Migrations
{
    [DbContext(typeof(WriteDbContext))]
    partial class WriteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("packing")
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CleanArchitectureSample.Domain.Entities.PackingList", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.Property<string>("_localization")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Localization");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("PackingLists", "packing");
                });

            modelBuilder.Entity("CleanArchitectureSample.Domain.ValueObjects.PackingItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsPacked")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("PackingListId")
                        .HasColumnType("uuid");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PackingListId");

                    b.ToTable("PackingItems", "packing");
                });

            modelBuilder.Entity("CleanArchitectureSample.Domain.ValueObjects.PackingItem", b =>
                {
                    b.HasOne("CleanArchitectureSample.Domain.Entities.PackingList", null)
                        .WithMany("_items")
                        .HasForeignKey("PackingListId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CleanArchitectureSample.Domain.Entities.PackingList", b =>
                {
                    b.Navigation("_items");
                });
#pragma warning restore 612, 618
        }
    }
}
