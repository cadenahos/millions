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
        var documents = await _database.Properties.ToListAsync();

        foreach (var doc in documents)
        {
            doc.Owner = await _database.Owners.FirstOrDefaultAsync(o => o.IdOwner == doc.IdOwner);
            doc.Images = await _database
                .PropertyImages.Where(p => p.IdProperty == doc.IdProperty)
                .ToListAsync();
        }

        return documents.Select(doc => doc.ToDomainEntity());
    }
}
