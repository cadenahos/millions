using Adapter.MongoDB.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Adapter.MongoDB;

public class PropertyDbContext : DbContext
{
    public DbSet<PropertyDocument> Properties { get; init; }
    public DbSet<OwnerDocument> Owners { get; init; }

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

        modelBuilder
            .Entity<PropertyDocument>()
            .HasOne(p => p.Owner)
            .WithMany()
            .HasForeignKey(p => p.IdOwner);
    }
}
