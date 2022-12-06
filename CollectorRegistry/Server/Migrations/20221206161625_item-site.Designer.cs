﻿// <auto-generated />
using System;
using CollectorRegistry.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CollectorRegistry.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221206161625_item-site")]
    partial class itemsite
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CollectorRegistry.Server.Models.Entry", b =>
                {
                    b.Property<int>("EntryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntryID"));

                    b.Property<DateTime>("ActualEntryDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deceased")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EntryDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EntryIP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ForSale")
                        .HasColumnType("bit");

                    b.Property<decimal?>("GeoLat")
                        .HasPrecision(10, 8)
                        .HasColumnType("decimal(10,8)");

                    b.Property<decimal?>("GeoLong")
                        .HasPrecision(11, 8)
                        .HasColumnType("decimal(11,8)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<decimal?>("ListPrice")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.Property<int?>("Mileage")
                        .HasColumnType("int");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TransactionPrice")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("EntryID");

                    b.HasIndex("ItemID");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("CollectorRegistry.Server.Models.EntryDefinition", b =>
                {
                    b.Property<int>("EntryDefinitionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntryDefinitionID"));

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiteID")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("EntryDefinitionID");

                    b.HasIndex("SiteID");

                    b.ToTable("EntryDefinitions");
                });

            modelBuilder.Entity("CollectorRegistry.Server.Models.EntryDefinitionOption", b =>
                {
                    b.Property<int>("EntryDefinitionOptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntryDefinitionOptionID"));

                    b.Property<int>("EntryDefinitionID")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntryDefinitionOptionID");

                    b.HasIndex("EntryDefinitionID");

                    b.ToTable("EntryDefinitionsOptions");
                });

            modelBuilder.Entity("CollectorRegistry.Server.Models.EntryValue", b =>
                {
                    b.Property<int>("EntryValueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntryValueID"));

                    b.Property<int>("EntryDefinitionID")
                        .HasColumnType("int");

                    b.Property<int?>("EntryDefinitionOptionID")
                        .HasColumnType("int");

                    b.Property<int?>("EntryID")
                        .HasColumnType("int");

                    b.HasKey("EntryValueID");

                    b.HasIndex("EntryDefinitionID");

                    b.HasIndex("EntryDefinitionOptionID");

                    b.HasIndex("EntryID");

                    b.ToTable("EntryValues");
                });

            modelBuilder.Entity("CollectorRegistry.Server.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemID"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiteID")
                        .HasColumnType("int");

                    b.HasKey("ItemID");

                    b.HasIndex("SiteID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("CollectorRegistry.Server.Models.Site", b =>
                {
                    b.Property<int>("SiteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SiteID"));

                    b.Property<string>("AboutText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subdomain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VinRegex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SiteID");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("CollectorRegistry.Server.Models.Entry", b =>
                {
                    b.HasOne("CollectorRegistry.Server.Models.Item", "Item")
                        .WithMany("Entries")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("CollectorRegistry.Server.Models.EntryDefinition", b =>
                {
                    b.HasOne("CollectorRegistry.Server.Models.Site", "Site")
                        .WithMany("EntryDefinitions")
                        .HasForeignKey("SiteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("CollectorRegistry.Server.Models.EntryDefinitionOption", b =>
                {
                    b.HasOne("CollectorRegistry.Server.Models.EntryDefinition", "EntryDefinition")
                        .WithMany("Options")
                        .HasForeignKey("EntryDefinitionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntryDefinition");
                });

            modelBuilder.Entity("CollectorRegistry.Server.Models.EntryValue", b =>
                {
                    b.HasOne("CollectorRegistry.Server.Models.EntryDefinition", "EntryDefinition")
                        .WithMany()
                        .HasForeignKey("EntryDefinitionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CollectorRegistry.Server.Models.EntryDefinitionOption", "Value")
                        .WithMany()
                        .HasForeignKey("EntryDefinitionOptionID");

                    b.HasOne("CollectorRegistry.Server.Models.Entry", null)
                        .WithMany("EntryValues")
                        .HasForeignKey("EntryID");

                    b.Navigation("EntryDefinition");

                    b.Navigation("Value");
                });

            modelBuilder.Entity("CollectorRegistry.Server.Models.Item", b =>
                {
                    b.HasOne("CollectorRegistry.Server.Models.Site", "Site")
                        .WithMany("Items")
                        .HasForeignKey("SiteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("CollectorRegistry.Server.Models.Entry", b =>
                {
                    b.Navigation("EntryValues");
                });

            modelBuilder.Entity("CollectorRegistry.Server.Models.EntryDefinition", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("CollectorRegistry.Server.Models.Item", b =>
                {
                    b.Navigation("Entries");
                });

            modelBuilder.Entity("CollectorRegistry.Server.Models.Site", b =>
                {
                    b.Navigation("EntryDefinitions");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
