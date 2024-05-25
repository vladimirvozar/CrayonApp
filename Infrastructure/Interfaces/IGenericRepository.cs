using Domain.Entities;
using Domain.Specifications;
using System.Linq.Expressions;

namespace Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> SingleOrDefaultAsync(ISpecification<T> spec);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<IReadOnlyList<T>> FindAsync(ISpecification<T> spec);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
        Task<int> CountAsync(ISpecification<T> spec);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
    }
}
