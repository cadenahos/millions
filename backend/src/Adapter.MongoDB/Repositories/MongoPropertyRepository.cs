using backend.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Adapter.MongoDB.Repositories;

public class MongoPropertyRepository : IPropertyRepository
{
    private readonly PropertyDbContext _database;

    //TO DO: add logging

    public MongoPropertyRepository(PropertyDbContext database)
    {
        _database = database;
    }

    public async Task<IEnumerable<PropertyEntity>> GetPropertiesAsync()
    {
        // var documents = _context.Properties.AsEnumerable();
        var documents = await _database.Properties.ToListAsync();
        return documents.Select(doc => doc.ToDomainEntity());
    }
}
