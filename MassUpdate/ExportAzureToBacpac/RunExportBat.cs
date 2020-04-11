using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ExportAzureToBacpac
{
    public class RunExportBat
    {
        // requires using Microsoft.Extensions.Configuration;
        private readonly IConfiguration Configuration;
        private ConnectionConfiguration currentConfiguration;

        public RunExportBat(IConfiguration configuration)
        {
            Configuration = configuration;

            currentConfiguration = new ConnectionConfiguration();
            currentConfiguration.SourceServerName = configuration.GetSection("SourceServerName").Value;
            currentConfiguration.SourceEncryptConnection = configuration.GetSection("SourceEncryptConnection").Value;
            currentConfiguration.TargetDirectory = configuration.GetSection("TargetDirectory").Value;
            currentConfiguration.SourceUser = configuration.GetSection("SourceUser").Value;
            currentConfiguration.SourcePassword = configuration.GetSection("SourcePassword").Value;
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
            Console.WriteLine($"Executing Azure export to bacpac for {currentDatabase} database");
            // var commandToRun = @"ExportFromAzureSQLDb.bat myserver.database.windows.net MyDatabase D:\ImportSQLFromAzure\MyDatabase.bacpac DatabaseUser DatabasePassword";
            var targetFile = $"{currentConfiguration.TargetDirectory}\\{currentDatabase}.bacpac";
            var args = $"{currentConfiguration.SourceServerName} {currentDatabase} {targetFile} {currentConfiguration.SourceUser} {currentConfiguration.SourcePassword}";
            var processInfo = new ProcessStartInfo("ExportFromAzureSQLDb.bat", args);
            var process =  Process.Start(processInfo);
            process.WaitForExit();
            Console.WriteLine($"{currentDatabase} database done");
        }

    }
}
