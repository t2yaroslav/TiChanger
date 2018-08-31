using System;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using TIC.ApiClient.Model;

namespace TIC.ParserStart
{
    class Program
    {
        static void Main(string[] args)
        {
            // configurations
            var environment = GetEnvironment();
            var configuration = BuildConfiguration(args, environment);
            
            // app start
            Console.WriteLine("Start ...");
            var restClient = new ApiClient.ApiClient();

            var filter = new ExchangersListFilter()
            {
                startFrom = 0
            };

            var exchangers = restClient.GetExchangerList(filter);
            filter.startFrom = 20;

            var exchangers2 = restClient.GetExchangerList(filter);
            Console.WriteLine("... end.");
        }
        
        // configuration
        private static IConfigurationRoot BuildConfiguration(string[] args, string environment)
        {
            IConfigurationBuilder _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var ebEnvironmentName = "";

            if (!string.IsNullOrEmpty(ebEnvironmentName)) {
                environment = ebEnvironmentName;
            }
            
            _config.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            
            return _config.Build();
        }
        
        private static string GetEnvironment()
        {
            return System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ??
                   EnvironmentName.Development;
        }
        
        private static FileVersionInfo GetProductInfo()
        {
            return FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
        
        private static bool IsDevelop(string environment = null)
        {
            return string.Equals(environment ?? GetEnvironment(), EnvironmentName.Development, StringComparison.OrdinalIgnoreCase);
        }
        
    }
}