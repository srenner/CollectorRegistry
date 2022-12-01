using Microsoft.EntityFrameworkCore;
using System;
using CollectorRegistry.Server.Models;

namespace CollectorRegistry.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Site> Sites { get; set; }
    }
}
