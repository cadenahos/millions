
using backend.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Adapter.MongoDB.Models;

public class PropertyImageDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string IdPropertyImage { get; set; } = string.Empty;
    public string IdProperty { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public bool Enabled { get; set; }

    public PropertyImageEntity ToDomainEntity()
    {
        return new PropertyImageEntity
        {
            IdPropertyImage = IdPropertyImage,
            IdProperty = IdProperty,
            Url = Url,
            Enabled = Enabled
        };
    }

    public static PropertyImageDocument ToPropertyImageDocument(PropertyImageEntity propertyImage)
    {
        return new PropertyImageDocument
        {
            IdPropertyImage = propertyImage.IdPropertyImage,
            IdProperty = propertyImage.IdProperty,
            Url = propertyImage.Url,
            Enabled = propertyImage.Enabled
        };
    }
}
