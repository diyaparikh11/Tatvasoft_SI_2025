using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Mission.Entities
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MissionDBContext>
    {
        public MissionDBContext CreateDbContext(string[] args)
        {
            // 👇 Dynamically get path to Mission.Api where appsettings.json is
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Mission.Api");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath) // 👈 this is the fix
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<MissionDBContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new MissionDBContext(builder.Options);
        }
    }
}