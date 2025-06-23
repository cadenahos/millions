using Adapter.MongoDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Adapter.MongoDB;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDB");
        var databaseName = "millions";

        var mongoClient = new MongoClient(connectionString);
        _database = mongoClient.GetDatabase(databaseName);

        // var dbContextOptions = new DbContextOptionsBuilder<PropertyDbContext>().UseMongoDB(
        //     mongoClient,
        //     databaseName
        // );
        // var client = new PropertyDbContext(dbContextOptions.Options);
        // _database = client.Properties;
    }

    public IMongoCollection<PropertyDocument> Properties =>
        _database.GetCollection<PropertyDocument>("properties");
}
