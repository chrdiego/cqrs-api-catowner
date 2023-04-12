using System.Linq.Expressions;
using CAT.Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace CAT.Infrastructure.Repository
{
    public class GenericRepository<TKey> : IGenericRepository<TKey>
    {
        protected readonly DbContext Context;

        protected GenericRepository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TContext GetContext<TContext>() where TContext : DbContext
        {
            return (TContext)Context;
        }

        public DbSet<TEntity> GetEntity<TEntity>()
            where TEntity : class,
            IEntityBase<TKey>
        {
            return Context.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync<TEntity>(TEntity entity,
                                                CancellationToken cancellationToken = default)
                                                    where TEntity : class,
                                                    IEntityBase<TKey>
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return await ProcessCreateAsync(entity, cancellationToken);
        }

        private async Task<TEntity> ProcessCreateAsync<TEntity>(TEntity entity,
                                                                CancellationToken cancellationToken)
        where TEntity : class, IEntityBase<TKey>
        {
            await Context.AddAsync(entity, cancellationToken);

            await Context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public Task<bool> UpdateAsync<TEntity>(TEntity entity,
                                               CancellationToken cancellationToken = default)
                                                      where TEntity : class,
                                                      IEntityBase<TKey>
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return ProcessUpdateAsync(entity, cancellationToken);
        }

        private async Task<bool> ProcessUpdateAsync<TEntity>(TEntity entity,
                                                             CancellationToken cancellationToken)
                                                                    where TEntity : class,
                                                                    IEntityBase<TKey>
        {
            Context.Set<TEntity>().Update(entity);

            bool success = await Context.SaveChangesAsync(cancellationToken) > 0;

            return success;
        }

        public Task<bool> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> predicate,
                                               CancellationToken cancellationToken = default)
                                               where TEntity : class,
                                               IEntityBase<TKey>
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return ProcessDeleteAsync(predicate, cancellationToken);
        }

        private async Task<bool> ProcessDeleteAsync<TEntity>(Expression<Func<TEntity, bool>> predicate,
                                                             CancellationToken cancellationToken)
                                                             where TEntity : class,
                                                             IEntityBase<TKey>
        {
            TEntity entity = await Context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();

            if (entity == null)
            {
                return false;
            }

            Context.Set<TEntity>().Remove(entity);

            return await Context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
