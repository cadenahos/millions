using System;
using System.Collections.Generic;
using System.Linq;
using Adapter.MongoDB.Models;
using Microsoft.EntityFrameworkCore.Storage;
using MongoDB.Bson;

namespace Adapter.MongoDB
{
    public static class DataSeeder
    {
        public static async void Seed(MongoDbContext context)
        {
            List<OwnerDocument> owners;
            if (!context.Owners.Any())
            {
                owners = new List<OwnerDocument>();
                for (int i = 1; i <= 20; i++)
                {
                    owners.Add(
                        new OwnerDocument
                        {
                            IdOwner = ObjectId.GenerateNewId().ToString(),
                            Name = $"Owner {i}",
                            Adress = $"{i} Main St",
                            Photo = $"https://example.com/photo{i}.jpg",
                            Birthday = new DateTime(1980 + i, 1, 1),
                        }
                    );
                }
                await context.propertiesContext.Owners.AddRangeAsync(owners);
                await context.propertiesContext.SaveChangesAsync();
            }
            else
            {
                owners = context.Owners.ToList();
            }

            if (!context.Properties.Any())
            {
                var properties = new List<PropertyDocument>();
                var random = new Random();
                for (int i = 1; i <= 300; i++)
                {
                    properties.Add(
                        new PropertyDocument
                        {
                            IdProperty = ObjectId.GenerateNewId().ToString(),
                            IdOwner = owners[0].IdOwner,
                            Name = $"Property {i}",
                            Address = $"{i} Property St",
                            Price = random.Next(100000, 1000000),
                            CodeInternal = $"P{i:D4}",
                            Year = random.Next(2000, 2024),
                        }
                    );
                }
                await context.propertiesContext.Properties.AddRangeAsync(properties);
                await context.propertiesContext.SaveChangesAsync();
            }
        }
    }
}
