using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SoftwareProductRepository : ISoftwareProductRepository
    {
        private readonly StoreContext _context;

        public SoftwareProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<SoftwareProduct>> GetAllAsync()
        {
            return await _context.SoftwareProducts
                .Include(sp => sp.Licenses)
                .ToListAsync();
        }
    }
}
