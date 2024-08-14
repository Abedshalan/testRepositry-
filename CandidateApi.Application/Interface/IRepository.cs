using System.Linq.Expressions;
using CandidateApi.Domain.Entities;

namespace CandidateApi.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Update(T entity);
        void UpdateEntityValues(T existingEntity, T newEntity); 
        void Delete(T entity);
        Task<int> SaveChangesAsync();
    }
}
