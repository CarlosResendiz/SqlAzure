using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ExportAzureToBacpac
{
    class Program
    {
        public static IConfigurationRoot configuration;
        private static ConnectionConfiguration currentConfiguration;

        public static object Log { get; private set; }

        static void Main(string[] args)
        {

            // Create service collection            
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider            
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            // Print connection string to demonstrate configuration object is populated
            //Console.WriteLine(configuration.GetConnectionString("DataConnection"));


            RunExportBat runBat = new RunExportBat(configuration);
            runBat.Run();

        }
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            
            // Build configuration
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton(configuration);

            // Add app
            serviceCollection.AddTransient<RunExportBat>();
        }
    }
}
