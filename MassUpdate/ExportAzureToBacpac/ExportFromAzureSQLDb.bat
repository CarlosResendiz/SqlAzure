@echo off
echo Server %1
echo Database: %2
echo TargetFile: %3
echo DatabaseUser: %4
echo DatabasePassword: %5

chdir /d C:\Program Files\Microsoft SQL Server\150\DAC\bin\
SQLPackage.exe /Action:Export ^
/SourceServerName:%1 ^
/SourceDatabaseName:%2% ^
/SourceEncryptConnection:True ^
/TargetFile:%3 ^
/SourceUser:%4 ^
/SourcePassword:%5
chdir /d %~dp0