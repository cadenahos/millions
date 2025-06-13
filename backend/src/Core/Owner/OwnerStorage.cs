namespace backend.Core;

public class OwnerStorage : IOwnerRepository
{
    private List<Owner> listOwners = new List<Owner>();

    public Task<IEnumerable<Owner>> GetOwnersAsync()
    {
        this.listOwners.Add(new Owner { IdOwner = Guid.NewGuid(), Name = "Owner 1" });
        this.listOwners.Add(new Owner { IdOwner = Guid.NewGuid(), Name = "Owner 2" });

        return Task.FromResult(listOwners.AsEnumerable());
    }

    public Task<Owner> GetOwnerAsync(Guid idOwner)
    {
        return Task.FromResult(listOwners.FirstOrDefault(x => x.IdOwner == idOwner));
    }

    public Task<Owner> AddOwnerAsync(Owner owner)
    {
        owner.IdOwner = Guid.NewGuid();
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
        var index = listOwners.FindIndex(x => x.IdOwner == idOwner);
        listOwners.RemoveAt(index);

        return Task.FromResult(true);
    }
}
