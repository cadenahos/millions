namespace backend.Core;

public class OwnerService : IOwnerService
{
    private IOwnerRepository _ownerStorage;

    public OwnerService(IOwnerRepository ownerStorage)
    {
        _ownerStorage = ownerStorage;
    }

    public async Task<IEnumerable<Owner>> GetOwnersAsyc()
    {
        var data = await _ownerStorage.GetOwnersAsync();
        if (data == null)
            throw new Exception("Owners not found");
        return await Task.FromResult(data);
    }

    public async Task<Owner> GetOwnerAsync(Guid idOwner)
    {
        var data = await _ownerStorage.GetOwnerAsync(idOwner);
        if (data == null)
            throw new Exception("Owner not found");
        return await Task.FromResult(data);
    }

    public async Task<Owner> AddOwnerAsync(Owner owner)
    {
        if (owner == null)
            throw new Exception("Owner not found");
        var data = await _ownerStorage.AddOwnerAsync(owner);
        return await Task.FromResult(data);
    }

    public async Task<Owner> UpdateOwnerAsync(Owner owner)
    {
        if (owner == null)
            throw new Exception("Owner not found");
        var data = await _ownerStorage.UpdateOwnerAsync(owner);
        return await Task.FromResult(data);
    }

    public async Task<bool> DeleteOwnerAsync(Guid idOwner)
    {
        if (idOwner == null || idOwner == Guid.Empty)
            throw new Exception("Owner not found");
        var data = await _ownerStorage.DeleteOwnerAsync(idOwner);
        return await Task.FromResult(data);
    }
}
