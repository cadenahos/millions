namespace backend.Core;

public interface IOwnerService
{
    Task<IEnumerable<Owner>> GetOwnersAsyc();
    Task<Owner> GetOwnerAsync(Guid idOwner);
    // Task<Owner> AddOwnerAsync(Owner owner);
    // Task<Owner> UpdateOwnerAsync(Owner owner);
    // Task<bool> DeleteOwnerAsync(Guid idOwner);
}
