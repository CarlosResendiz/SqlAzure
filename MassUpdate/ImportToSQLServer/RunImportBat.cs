using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ImportToSQLServer
{
    public class RunImportBat
    {
        // requires using Microsoft.Extensions.Configuration;
        private readonly IConfiguration Configuration;
        private ConnectionConfiguration currentConfiguration;

        public RunImportBat(IConfiguration configuration)
        {
            Configuration = configuration;

            currentConfiguration = new ConnectionConfiguration();

            currentConfiguration.TargetServerName = configuration.GetSection("TargetServerName").Value;
            currentConfiguration.SourceDirectory = configuration.GetSection("SourceDirectory").Value;
            currentConfiguration.DatabasesTextFileName = configuration.GetSection("DatabasesTextFileName").Value;

        }

        public void Run()
        {

            Console.WriteLine("Exporting process started");

            var currentBasePath = Directory.GetParent(AppContext.BaseDirectory).FullName;

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader($"{currentBasePath}\\{currentConfiguration.DatabasesTextFileName}");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                consumeExportBatFile(line);
            }

            file.Close();

            Console.WriteLine("Exporting process finished");
            Console.ReadKey();

        }

        private void consumeExportBatFile(string currentDatabase)
        {
            Console.WriteLine($"Executing import for {currentDatabase} database to sql server {currentConfiguration.TargetServerName}");
            // var commandToRun = @"ExportFromAzureSQLDb.bat myserver.database.windows.net MyDatabase D:\ImportSQLFromAzure\MyDatabase.bacpac DatabaseUser DatabasePassword";
            var sourceFile = $"{currentConfiguration.SourceDirectory}\\{currentDatabase}.bacpac";
            var args = $"{currentConfiguration.TargetServerName} {currentDatabase} {sourceFile}";
            var processInfo = new ProcessStartInfo("ImportToSQLServer.bat", args);
            var process =  Process.Start(processInfo);
            process.WaitForExit();
            Console.WriteLine($"{currentDatabase} database done");
        }

    }
}
