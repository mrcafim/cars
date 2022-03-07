using Microsoft.EntityFrameworkCore;

namespace Cars.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbContext Context { get; }
        Task<List<TEntity>> List();
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Get(Guid id);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
    }
}
