using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MonitoringExample.Models;

namespace MonitoringExample.Data
{
	public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}

