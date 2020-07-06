using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace ImportToSQLServer
{
    class Program
    {
        public static IConfigurationRoot configuration;

        public static object Log { get; private set; }

        static void Main(string[] args)
        {

            // Create service collection            
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider            
            //IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            // Print connection string to demonstrate configuration object is populated
            //Console.WriteLine(configuration.GetConnectionString("DataConnection"));


            RunImportBat runBat = new RunImportBat(configuration);
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
            serviceCollection.AddTransient<RunImportBat>();
        }
    }
}
