chdir /d C:\Program Files\Microsoft SQL Server\150\DAC\bin\
SQLPackage.exe /Action:Export ^
/SourceServerName:testdbs.database.windows.net ^
/SourceDatabaseName:AdventureWorksLt ^
/SourceEncryptConnection:True ^
/TargetFile:D:\ImportSQL\AdventureWorksLt.bacpac ^
/SourceUser:myUser ^
/SourcePassword:myPassword
chdir /d %~dp0