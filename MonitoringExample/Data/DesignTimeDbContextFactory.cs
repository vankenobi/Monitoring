using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MonitoringExample.Data
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext> 
	{
        private IConfiguration _configuration;

		public DesignTimeDbContextFactory(IConfiguration configuration)
		{
            _configuration = configuration;
		}

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ApplicationDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(_configuration.GetConnectionString("postgresql"));
            return new ApplicationDbContext(dbContextOptionsBuilder.Options);
        }
    }
}

