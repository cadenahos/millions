namespace backend.Core;

public interface IPropertyService
{
    Task<IEnumerable<PropertyDTO>> GetPropertiesAsync();
}
