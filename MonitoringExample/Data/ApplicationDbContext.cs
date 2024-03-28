using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using MonitoringExample.Models;
using MonitoringExample.Monitoring;
using Prometheus;

namespace MonitoringExample.Data
{
	public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated(); 
            Database.Migrate();      
        }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            CustomMetrics.IncrementDbConnectionCounter();
        }

        public override void Dispose()
        {
            base.Dispose();
            CustomMetrics.DecrementDbConnectionCounter();

        }

    }
}