using Adapter.MongoDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Adapter.MongoDB;

public class MongoDbContext
{
    private readonly PropertyDbContext _context; //MongoClient

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

        _context = client;
    }

    public PropertyDbContext propertiesContext => _context;
    public DbSet<PropertyDocument> Properties => _context.Properties;
    public DbSet<OwnerDocument> Owners => _context.Owners;
    public DbSet<PropertyImageDocument> PropertyImages => _context.PropertyImages;
    public DbSet<PropertyTraceDocument> PropertyTraces => _context.PropertyTraces;
}
