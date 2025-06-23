using Adapter.MongoDB.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Adapter.MongoDB;

public class PropertyDbContext : DbContext
{
    public DbSet<PropertyDocument> Properties { get; init; }

    public static PropertyDbContext Create(IMongoDatabase database) =>
        new(
            new DbContextOptionsBuilder<PropertyDbContext>()
                .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
                .Options
        );

    public PropertyDbContext(DbContextOptions options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PropertyDocument>().ToCollection("properties");
    }
}
