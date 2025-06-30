using backend.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Adapter.MongoDB.Models;

public class PropertyDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string IdProperty { get; set; } = string.Empty;
    public string IdOwner { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int Price { get; set; }
    public string CodeInternal { get; set; } = string.Empty;
    public int Year { get; set; }

    [BsonElement("owner")]
    public OwnerDocument Owner { get; set; } = null!;

    [BsonElement("images")]
    public ICollection<PropertyImageDocument> Images { get; set; } =
        new List<PropertyImageDocument>();

    [BsonElement("trace")]
    public PropertyTraceDocument? Trace { get; set; }

    public PropertyEntity ToDomainEntity()
    {
        return new PropertyEntity(
            IdProperty,
            Owner.ToDomainEntity(),
            Name,
            Address,
            Price,
            CodeInternal,
            Year
        )
        {
            Images = Images.Select(i => i.ToDomainEntity()).ToList(),
            Trace = Trace?.ToDomainEntity(),
        };
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
