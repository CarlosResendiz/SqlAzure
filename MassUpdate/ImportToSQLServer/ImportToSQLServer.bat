@echo off
echo TargetServerName %1
echo TargetDatabaseName: %2
echo SourceFile: %3

chdir /d C:\Program Files\Microsoft SQL Server\150\DAC\bin\
SQLPackage.exe /Action:Import ^
/TargetServerName:%1 ^
/TargetDatabaseName:%2 ^
/SourceFile:%3
chdir /d %~dp0