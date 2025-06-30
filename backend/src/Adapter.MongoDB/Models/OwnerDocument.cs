using backend.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Adapter.MongoDB.Models;

public class OwnerDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string IdOwner { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Adress { get; set; }
    public string? Photo { get; set; }
    public DateTime? Birthday { get; set; }

    public Owner ToDomainEntity()
    {
        return new Owner(IdOwner, Name, Adress, Photo, Birthday);
    }

    public static OwnerDocument ToOwnerDocument(Owner owner)
    {
        return new OwnerDocument
        {
            IdOwner = owner.IdOwner,
            Name = owner.Name,
            Adress = owner.Adress,
            Photo = owner.Photo,
            Birthday = owner.Birthday,
        };
    }
}

