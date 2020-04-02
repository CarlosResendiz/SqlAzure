# Export SQL database from azure to sql

## Prerequisites
- [DacFramework] (https://go.microsoft.com/fwlink/?linkid=2113703) this will install sqlpackage in `C:\Program Files\Microsoft SQL Server\150\DAC\bin`

## Running ExportFromAzureSQLDb.bat
### Parameters in script

- `chdir /d C:\Program Files\Microsoft SQL Server\150\DAC\bin\` -> It changes current performance to folder with sql package
- `SQLPackage.exe /Action:Export ^` -> Indicates Export action(From Azure to .bacpac file)
- `/SourceServerName:myserver.database.windows.net ^` -> Server Name
- `/SourceDatabaseName:MyDatabase ^` -> Database Name
- `/SourceEncryptConnection:True ^` -> Enabling encrypted connection
- `/TargetFile:D:\ImportSQLFromAzure\MyDatabase.bacpac ^` -> Set where to write bacpac file locally
- `/SourceUser:user ^` -> Database User
- `/SourcePassword:` -> Database Password
- `chdir /d %~dp0` -> It changes from utility folder to bacpac file folder


For start running it and importing database, you should to open your azure database firewall for allowing connections for this ip.

## Running ImportToSQLServer.bat
### Parameters in script

- `chdir /d C:\Program Files\Microsoft SQL Server\150\DAC\bin\` -> It changes current performance to folder with sql package
- `SQLPackage.exe /Action:Import ^` -> Indicates Import action(From .bacpac file to sql database)
- `/TargetServerName:.\MySQLServer ^` -> .\MySQLServer is your sql database instance
- `/TargetDatabaseName:MyDatabase ^` -> MyDatabase is desired database
- `/TargetFile:D:\ImportSQLFromAzure\MyDatabase.bacpac ^` -> Source file which you get using `ExportFromAzureSQLDb.bat` file
- `chdir /d %~dp0` -> It changes from utility folder to script directory

Import might throw some warnings because you are migrating from cloud version to your local sql version(e.g. 2014/2016 etc.) but if you are not using any special feature from cloud version, just press enter and migration will continue normally.