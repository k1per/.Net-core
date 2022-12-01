## Prepare env, migrate db, build and run
```bash
docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=MyPass@word" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge
dotnet ef database update --project SuperHeroAPI
dotnet run --project SuperHeroAPI
open https://localhost:7122/swagger/index.html
```