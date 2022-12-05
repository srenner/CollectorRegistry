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
    [Migration("20221204222114_entry-updates-20221204")]
    partial class entryupdates20221204
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal?>("ListPrice")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.Property<int?>("Mileage")
                        .HasColumnType("int");

                    b.Property<bool>("OnRoad")
                        .HasColumnType("bit");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiteID")
                        .HasColumnType("int");

                    b.Property<decimal?>("TransactionPrice")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("EntryID");

                    b.HasIndex("SiteID");

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

            modelBuilder.Entity("CollectorRegistry.Server.Models.EntryValue", b =>
                {
                    b.Property<int>("EntryValueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntryValueID"));

                    b.Property<int>("EntryDefinitionID")
                        .HasColumnType("int");

                    b.Property<int?>("EntryID")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntryValueID");

                    b.HasIndex("EntryDefinitionID");

                    b.HasIndex("EntryID");

                    b.ToTable("EntryValues");
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
                    b.HasOne("CollectorRegistry.Server.Models.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
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

            modelBuilder.Entity("CollectorRegistry.Server.Models.EntryValue", b =>
                {
                    b.HasOne("CollectorRegistry.Server.Models.EntryDefinition", "EntryDefinition")
                        .WithMany()
                        .HasForeignKey("EntryDefinitionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CollectorRegistry.Server.Models.Entry", null)
                        .WithMany("EntryValues")
                        .HasForeignKey("EntryID");

                    b.Navigation("EntryDefinition");
                });

            modelBuilder.Entity("CollectorRegistry.Server.Models.Entry", b =>
                {
                    b.Navigation("EntryValues");
                });

            modelBuilder.Entity("CollectorRegistry.Server.Models.Site", b =>
                {
                    b.Navigation("EntryDefinitions");
                });
#pragma warning restore 612, 618
        }
    }
}
