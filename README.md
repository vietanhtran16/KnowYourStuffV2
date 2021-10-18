***Know Your Stuff API***

To switch between DB, update `AppSettings:DbType` to `MongoDb` otherwise it will default to `MsSQL`

To run this API, you need to run a local instance of the chosen DB
For MongoDB:
```
docker run -d -e MONGO_INITDB_ROOT_USERNAME=USERNAME -e MONGO_INITDB_ROOT_PASSWORD=PASSWORD -e MONGO_INITDB_DATABASE=KnowYourStuff --name mongodb -p 27017:27017 mongo
```

For MsSQL:
```bash
# default user name is SA
docker run -d -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Password' --name sqlserver -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest-ubuntu
# performs db migration with entity framework
./scripts/updateMsSQLDB.sh
```

After that, uses `dotnet user-secrets set` to set up required secrets for the chosen DB