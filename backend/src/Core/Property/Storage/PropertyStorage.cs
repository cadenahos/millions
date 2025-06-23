namespace backend.Core;

public class PropertyStorage : IPropertyRepository
{
    private List<PropertyEntity> listProperties = new List<PropertyEntity>();

    public Task<IEnumerable<PropertyEntity>> GetPropertiesAsync()
    {
        this.listProperties.Add(
            new PropertyEntity("23", "25", "New york home", "New York", 1000000, null, 199)
        );
        return Task.FromResult(listProperties.AsEnumerable());
    }
}
