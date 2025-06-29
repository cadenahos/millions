using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Adapter.MongoDB;

public class MongoDbContext
{
    public MongoDbContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDB");
        var databaseName = "millions";

        var mongoClient = new MongoClient(connectionString);
        var dbContextOptions = new DbContextOptionsBuilder<PropertyDbContext>().UseMongoDB(
            mongoClient,
            databaseName
        );
        var client = new PropertyDbContext(dbContextOptions.Options);
        client.Database.EnsureCreated();
    }
}
