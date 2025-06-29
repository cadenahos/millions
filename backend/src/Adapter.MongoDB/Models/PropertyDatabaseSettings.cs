namespace Adapter.MongoDB.Models;

public class PropertiesDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string PropertiesCollectionName { get; set; } = null!;
}
