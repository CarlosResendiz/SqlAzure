chdir /d C:\Program Files\Microsoft SQL Server\150\DAC\bin\
SQLPackage.exe /Action:Import ^
/TargetServerName:.\MySQLServer ^
/TargetDatabaseName:MyDatabase ^
/TargetFile:D:\ImportSQLFromAzure\MyDatabase.bacpac
chdir /d %~dp0