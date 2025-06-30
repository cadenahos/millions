using System;
using System.Collections.Generic;
using System.Linq;
using Adapter.MongoDB.Models;
using Microsoft.EntityFrameworkCore;
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
                owners = await context.propertiesContext.Owners.ToListAsync();
            }

            List<PropertyDocument> properties;
            if (!context.Properties.Any())
            {
                properties = new List<PropertyDocument>();
                var random = new Random();
                int count = 0;
                for (int i = 1; i <= 300; i++)
                {
                    PropertyDocument property = new PropertyDocument
                    {
                        IdProperty = ObjectId.GenerateNewId().ToString(),
                        IdOwner = owners[0].IdOwner, // Assign to a random owner
                        Name = $"Property {i}",
                        Address = $"{i} Property St",
                        Price = random.Next(100000, 1000000),
                        CodeInternal = $"P{i:D4}",
                        Year = random.Next(2000, 2024),
                    };

                    properties.Add(property);
                    if (!context.PropertyImages.Any())
                    {
                        var propertyImages = new List<PropertyImageDocument>();
                        {
                            var imageCount = random.Next(1, 5); // 1 to 4 images
                            for (int img = 0; img < imageCount; img++)
                            {
                                propertyImages.Add(
                                    new PropertyImageDocument
                                    {
                                        IdPropertyImage = ObjectId.GenerateNewId().ToString(),
                                        IdProperty = property.IdProperty,
                                        Url =
                                            $"https://picsum.photos/seed/{Guid.NewGuid()}/800/600",
                                        Enabled = true,
                                    }
                                );
                            }
                        }
                        await context.propertiesContext.PropertyImages.AddRangeAsync(
                            propertyImages
                        );
                    }

                    if (!context.PropertyTraces.Any())
                    {
                        var propertyTraces = new List<PropertyTraceDocument>();
                        // Add traces for a subset of properties
                        propertyTraces.Add(
                            new PropertyTraceDocument
                            {
                                IdPropertyTrace = ObjectId.GenerateNewId().ToString(),
                                IdProperty = property.IdProperty,
                                DateSale = DateTime.UtcNow.AddDays(-random.Next(30, 365 * 5)),
                                Name = $"Sale of {property.Name}",
                                Value =
                                    property.Price
                                    * (decimal)(1 + (random.NextDouble() * 0.4 - 0.2)), // +/- 20% of price
                                Tax = property.Price * 0.08m, // 8% tax
                            }
                        );
                        await context.propertiesContext.PropertyTraces.AddRangeAsync(
                            propertyTraces
                        );
                    }

                    if (i == 100 || i == 200)
                    {
                        count++;
                    }
                }
                await context.propertiesContext.Properties.AddRangeAsync(properties);
                await context.propertiesContext.SaveChangesAsync();
            }
            else
            {
                properties = await context.propertiesContext.Properties.ToListAsync();
            }
        }
    }
}
