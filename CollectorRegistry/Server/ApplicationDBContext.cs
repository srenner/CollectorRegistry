using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;
using CollectorRegistry.Server.AggregatesModel.EntryAggregate;
using CollectorRegistry.Server.AggregatesModel.SiteAggregate;
using CollectorRegistry.Server.AggregatesModel.ItemAggregate;

namespace CollectorRegistry.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Item> Items { get; set; } 
        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryDefinition> EntryDefinitions { get; set; }
        public DbSet<EntryDefinitionOption> EntryDefinitionsOptions { get; set; }
        public DbSet<EntryValue> EntryValues { get; set; }
    }
}
