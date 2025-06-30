using Adapter.MongoDB.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Adapter.MongoDB;

public class PropertyDbContext : DbContext
{
    public DbSet<PropertyDocument> Properties { get; init; }
    public DbSet<OwnerDocument> Owners { get; init; }
    public DbSet<PropertyImageDocument> PropertyImages { get; init; }
    public DbSet<PropertyTraceDocument> PropertyTraces { get; init; }

    public static PropertyDbContext Create(IMongoDatabase database) =>
        new(
            new DbContextOptionsBuilder<PropertyDbContext>()
                .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
                .Options
        );

    public PropertyDbContext(DbContextOptions options)
        : base(options)
    {
        Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PropertyDocument>().ToCollection("properties");
        modelBuilder.Entity<OwnerDocument>().ToCollection("owners");
        modelBuilder.Entity<PropertyImageDocument>().ToCollection("propertyImages");
        modelBuilder.Entity<PropertyTraceDocument>().ToCollection("propertyTraces");

        modelBuilder.Entity<OwnerDocument>().HasKey(o => o.IdOwner);
        modelBuilder.Entity<PropertyDocument>().HasKey(p => p.IdProperty);
        modelBuilder.Entity<PropertyImageDocument>().HasKey(pi => pi.IdPropertyImage);
        modelBuilder.Entity<PropertyTraceDocument>().HasKey(pt => pt.IdPropertyTrace);

        modelBuilder
            .Entity<PropertyDocument>()
            .HasOne(p => p.Owner)
            .WithMany()
            .HasForeignKey(p => p.IdOwner);
    }
}
