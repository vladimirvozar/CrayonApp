using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISoftwareProductRepository
    {
        Task<IReadOnlyList<SoftwareProduct>> GetAllAsync();
    }
}
