using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Rubin2000.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Rubin2000DbContext>
    {
        public Rubin2000DbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<Rubin2000DbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new Rubin2000DbContext(optionsBuilder.Options);
        }
    }
}
