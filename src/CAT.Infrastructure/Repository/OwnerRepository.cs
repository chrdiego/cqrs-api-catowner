using CAT.Domain.Entities;
using CAT.Domain.Repository;
using CAT.Infrastructure.Context;

namespace CAT.Infrastructure.Repository
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(CatDbContext context) : base(context)
        {
        }
    }
}
