using CAT.Domain.Primitives;
using CAT.Domain.Repository;
using CAT.Infrastructure.Context;

namespace CAT.Infrastructure.Repository
{
    public class CatRepository : GenericRepository<int>, ICatRepository
    {
        public CatRepository(CatDbContext context) : base(context)
        {
        }
    }
}
