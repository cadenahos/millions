namespace backend.Core;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyStorage;

    public PropertyService(IPropertyRepository propertyStorage) =>
        _propertyStorage = propertyStorage;

    public async Task<IEnumerable<PropertyEntity>> GetPropertiesAsync()
    {
        var data = await _propertyStorage.GetPropertiesAsync();
        if (data == null)
            throw new Exception("Properties not found");
        return await Task.FromResult(data);
    }
}
