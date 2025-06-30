namespace backend.Core;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyStorage;

    public PropertyService(IPropertyRepository propertyStorage) =>
        _propertyStorage = propertyStorage;

    public async Task<IEnumerable<PropertyDTO>> GetPropertiesAsync()
    {
        var data = await _propertyStorage.GetPropertiesAsync();
        var result = data.Select(x => x.ToDTO());
        if (data == null)
            throw new Exception("Properties not found");
        return result;
    }
}
