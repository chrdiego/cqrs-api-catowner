using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CAT.Domain.Primitives
{
    public interface IGenericRepository<TKey>
    {
        TContext GetContext<TContext>() where TContext : DbContext;

        DbSet<TEntity> GetEntity<TEntity>()
            where TEntity : class, IEntityBase<TKey>;

        Task<TEntity> CreateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
                                            where TEntity : class,
                                            IEntityBase<TKey>;

        Task<bool> UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
                                        where TEntity : class,
                                        IEntityBase<TKey>;

        Task<bool> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> predicate,
                                        CancellationToken cancellationToken = default)
                                                                where TEntity : class,
                                                                IEntityBase<TKey>;
    }
}
