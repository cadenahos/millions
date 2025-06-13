namespace backend.Core;

public interface IPropertyRepository
{
    Task<IEnumerable<PropertyEntity>> GetPropertiesAsync();
}
