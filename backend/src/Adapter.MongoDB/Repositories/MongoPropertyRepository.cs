using backend.Core;
using Microsoft.EntityFrameworkCore;
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
        var documents = await _database.Properties.ToListAsync();
        // var documents = await _database.Properties.AsQueryable().ToListAsync();
        return documents.Select(doc => doc.ToDomainEntity());
    }
}
