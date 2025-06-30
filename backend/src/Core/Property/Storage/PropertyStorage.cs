namespace backend.Core;

public class PropertyStorage : IPropertyRepository
{
    private List<PropertyEntity> listProperties = new List<PropertyEntity>();

    public Task<IEnumerable<PropertyEntity>> GetPropertiesAsync()
    {
        var owner = new Owner("1", "John Doe", "123 Main St", null, DateTime.Now.AddYears(-30));
        this.listProperties.Add(
            new PropertyEntity("23", owner, "New york home", "New York", 1000000, "CX123", 1999)
        );
        return Task.FromResult(listProperties.AsEnumerable());
    }
}
