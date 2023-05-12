using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CAT.Domain.Primitives
{
    public interface IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);
    }
}
