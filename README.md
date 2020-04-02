# Export SQL database from azure to sql

## Prerequisites
- [DacFramework] (https://go.microsoft.com/fwlink/?linkid=2113703) this will install sqlpackage in `C:\Program Files\Microsoft SQL Server\150\DAC\bin`

## Running ExportFromAzureSQLDb.bat
### Parameters

- `chdir /d C:\Program Files\Microsoft SQL Server\150\DAC\bin\` -> It changes current performance to folder with sql package
- `SQLPackage.exe /Action:Export ^` -> Indicates Export action
- `/SourceServerName:testdbs.database.windows.net ^` -> Server Name
- `/SourceDatabaseName:AdventureWorksLt ^` -> Database Name
- `/SourceEncryptConnection:True ^` -> Enabling encrypted connection
- `/TargetFile:D:\ImportSQL\AdventureWorksLt.bacpac ^` -> Set where to write bacpac file locally
- `/SourceUser:user ^` -> Database User
- `/SourcePassword:` -> Database Password
- `chdir /d %~dp0` -> It changes from utility folder to bacpac file folder

