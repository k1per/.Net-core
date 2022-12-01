default master branch
switch to branches to try other integrations

#start sqlserver
docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=MyPass@word" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge
#migrate db
dotnet ef database update --project SuperHeroAPI
#start application
dotnet run --project SuperHeroAPI
#use swagger
open https://localhost:7122/swagger/index.html