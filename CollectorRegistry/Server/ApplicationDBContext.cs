using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;
using CollectorRegistry.Server.Aggregates.EntryAggregate;
using CollectorRegistry.Server.Aggregates.SiteAggregate;
using CollectorRegistry.Server.Aggregates.ItemAggregate;

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
