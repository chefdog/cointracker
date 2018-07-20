
1. Credits
https://blogs.msdn.microsoft.com/mihansen/2017/09/10/managing-secrets-in-net-core-2-0-apps/
https://www.codeproject.com/Articles/1205160/ASP-NET-Core-Bearer-Authentication

2. API
Example: https://api.coinmarketcap.com/v1/ticker/
Example: https://api.coinmarketcap.com/v1/ticker/?limit=10
Example: https://api.coinmarketcap.com/v1/ticker/?start=100&limit=10
Example: https://api.coinmarketcap.com/v1/ticker/?convert=EUR&limit=10

3. Running migrations
After you've defined your initial model, it's time to create the database. To do this, add an initial migration.

3.1. SQL Server (Azure)
run the command : "Add-Migration InitialCreate -project CryptoTracker.Common -Context CTDbContext -OutputDir Migrations\SqlServerMigrations"
and next: "Update-Database"

3.2. SQLite (filebased, runs under linux, windows)
run the command : "Add-Migration InitialCreate -project CryptoTracker.Common -Context CTDbsqliteContext -OutputDir Migrations\SqliteMigrations"
and next: "Update-Database InitialCreate"

Appendix
100.1 Depency injection issues
When injection appsettings, make sur you inject IOptions<AppSettings> in your services.
