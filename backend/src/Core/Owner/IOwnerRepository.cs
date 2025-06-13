namespace backend.Core;

public interface IOwnerRepository
{
    Task<IEnumerable<Owner>> GetOwnersAsync();
    Task<Owner> GetOwnerAsync(Guid idOwner);
    Task<Owner> AddOwnerAsync(Owner owner);
    Task<Owner> UpdateOwnerAsync(Owner owner);
    Task<bool> DeleteOwnerAsync(Guid idOwner);
}
