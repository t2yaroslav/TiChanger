using System.Diagnostics;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TIC.Data.MySql
{
    public class DataContextDesignTimeFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            var environment = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            Trace.WriteLine($"BasePath: {basePath}");
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(basePath)
               .AddJsonFile("appsettings.json")
               .AddJsonFile($"appsettings.{environment}.json")
               .Build();
            var connectionString = configuration.GetConnectionString("MySqlConnection");

            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseMySql(connectionString);
            
            return new DataContext(builder.Options);
        }
    }
}