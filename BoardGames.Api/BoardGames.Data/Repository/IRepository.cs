using BoardGames.Data.Entities;
using System.Linq.Expressions;

namespace BoardGames.Data.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        public IQueryable<T> GetAllAsNoTracking();
        public Task<T> GetAsync(Guid id);
        public Task<T> GetAsync(Guid id, params Expression<Func<T, object>>[] includePaths);
        public Task CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(T entity);
        public void Remove(T entity);
        public Task SaveChangesAsync();
        public IQueryable<T> GetAll();
    }
}
