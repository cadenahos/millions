using backend.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Adapter.MongoDB.Models;

public class PropertyDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string IdProperty { get; set; }
    public string IdOwner { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int Price { get; set; }
    public string CodeInternal { get; set; }
    public int Year { get; set; }

    [BsonIgnore]
    public OwnerDocument Owner { get; set; }

    public PropertyEntity ToDomainEntity()
    {
        return new PropertyEntity(IdProperty, Owner.ToDomainEntity(), Name, Address, Price, CodeInternal, Year);
    }

    public static PropertyDocument ToPropertyDocument(PropertyEntity property)
    {
        return new PropertyDocument
        {
            IdOwner = property.Owner.IdOwner,
            Name = property.Name,
            Address = property.Address,
            Price = property.Price,
            CodeInternal = property.CodeInternal,
            Year = property.Year,
        };
    }
}
