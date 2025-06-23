namespace backend.Core;

public class OwnerStorage : IOwnerRepository
{
    private List<Owner> listOwners = new List<Owner>();

    public Task<IEnumerable<Owner>> GetOwnersAsync()
    {
        this.listOwners.Add(new Owner("124", "Owner 1", null, null, null));
        this.listOwners.Add(new Owner("125", "Owner 5", null, null, null));
        return Task.FromResult(listOwners.AsEnumerable());
    }

    public Task<Owner> GetOwnerAsync(Guid idOwner)
    {
        return Task.FromResult(listOwners.FirstOrDefault(x => x.IdOwner.Equals(idOwner)));
    }

    public Task<Owner> AddOwnerAsync(Owner owner)
    {
        owner.IdOwner = "3";
        listOwners.Add(owner);

        return Task.FromResult(owner);
    }

    public Task<Owner> UpdateOwnerAsync(Owner owner)
    {
        var index = listOwners.FindIndex(x => x.IdOwner == owner.IdOwner);
        listOwners[index] = owner;

        return Task.FromResult(owner);
    }

    public Task<bool> DeleteOwnerAsync(Guid idOwner)
    {
        var index = listOwners.FindIndex(x => x.IdOwner.Equals(idOwner));
        listOwners.RemoveAt(index);

        return Task.FromResult(true);
    }
}
