
using backend.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Adapter.MongoDB.Models;

public class PropertyTraceDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string IdPropertyTrace { get; set; } = string.Empty;
    public string IdProperty { get; set; } = string.Empty;
    public DateTime DateSale { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public decimal Tax { get; set; }

    public PropertyTraceEntity ToDomainEntity()
    {
        return new PropertyTraceEntity
        {
            IdPropertyTrace = IdPropertyTrace,
            IdProperty = IdProperty,
            DateSale = DateSale,
            Name = Name,
            Value = Value,
            Tax = Tax
        };
    }

    public static PropertyTraceDocument ToPropertyTraceDocument(PropertyTraceEntity propertyTrace)
    {
        return new PropertyTraceDocument
        {
            IdPropertyTrace = propertyTrace.IdPropertyTrace,
            IdProperty = propertyTrace.IdProperty,
            DateSale = propertyTrace.DateSale,
            Name = propertyTrace.Name,
            Value = propertyTrace.Value,
            Tax = propertyTrace.Tax
        };
    }
}
