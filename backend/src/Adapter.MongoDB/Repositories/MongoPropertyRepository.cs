using Adapter.MongoDB;
using Adapter.MongoDB.Models;
using backend.Core;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Adapter.MongoDB.Repositories;

public class MongoPropertyRepository : IPropertyRepository
{
    private readonly MongoDbContext _database;

    //TO DO: add logging

    public MongoPropertyRepository(MongoDbContext database)
    {
        _database = database;
    }

    public async Task<IEnumerable<PropertyEntity>> GetPropertiesAsync()
    {
        // var documents = _context.Properties.AsEnumerable();
        var documents = await _database.Properties.Find(_ => true).ToListAsync();
        return documents.Select(doc => doc.ToDomainEntity());
    }
}
