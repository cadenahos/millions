namespace backend.Core;

public class PropertyStorage : IPropertyRepository
{
    private List<PropertyEntity> listProperties = new List<PropertyEntity>();

    public Task<IEnumerable<PropertyEntity>> GetPropertiesAsync()
    {
        this.listProperties.Add(
            new PropertyEntity
            {
                IdProperty = Guid.NewGuid(),
                IdOwner = Guid.NewGuid(),
                Name = "New york home",
                Address = "New York",
                Price = 1000000,
            }
        );
        return Task.FromResult(listProperties.AsEnumerable());
    }
}
