using backend.Core;

namespace backend.Core.Tests;

public class OwnerTests
{
    [Fact]
    public async Task WhenGetOwners_ThenShouldReturnOwners()
    {
        var ownerService = new OwnerService(new OwnerStorage());
        var owners = await ownerService.GetOwnersAsyc();
        Assert.NotEmpty(owners);
    }
}
