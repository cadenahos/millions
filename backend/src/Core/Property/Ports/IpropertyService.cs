namespace backend.Core;

public interface IPropertyService
{
    Task<IEnumerable<PropertyEntity>> GetPropertiesAsync();
}
