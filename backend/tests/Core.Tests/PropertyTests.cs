using backend.Core;

namespace backend.Core.Tests;

public class PropertyTests
{
    [Fact]
    public async Task WhenGetProperties_ThenShouldReturnProperties()
    {
        var propertyService = new PropertyService(new PropertyStorage());
        var properties = await propertyService.GetPropertiesAsync();
        Assert.NotEmpty(properties);
    }
}
