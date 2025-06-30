using backend.Core;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.RestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PropertyController : ControllerBase
{
    private readonly IPropertyService _propertyService;

    public PropertyController(IPropertyService propertyService)
    {
        _propertyService = propertyService;
    }

    [HttpGet]
    public async Task<IEnumerable<PropertyDTO>> GetPropertiesAsync()
    {
        return await _propertyService.GetPropertiesAsync();
    }
}
