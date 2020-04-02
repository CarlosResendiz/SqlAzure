chdir /d C:\Program Files\Microsoft SQL Server\150\DAC\bin\
SQLPackage.exe /Action:Export ^
/SourceServerName:myserver.database.windows.net ^
/SourceDatabaseName:MyDatabase ^
/SourceEncryptConnection:True ^
/TargetFile:D:\ImportSQLFromAzure\MyDatabase.bacpac ^
/SourceUser:myUser ^
/SourcePassword:myPassword
chdir /d %~dp0