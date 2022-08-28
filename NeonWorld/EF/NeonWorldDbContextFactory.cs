using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NeonWorld.EF
{
    public class NeonWorldDbContextFactory : IDesignTimeDbContextFactory<NeonWorldDbContext>
    {
        public NeonWorldDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("NeonWorldDb");

            var optionsBuilder = new DbContextOptionsBuilder<NeonWorldDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new NeonWorldDbContext(optionsBuilder.Options);
        }
    }
}
