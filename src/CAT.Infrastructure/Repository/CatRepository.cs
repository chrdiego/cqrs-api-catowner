using CAT.Domain.Entities;
using CAT.Domain.Primitives;
using CAT.Domain.Repository;
using CAT.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CAT.Infrastructure.Repository
{
    public class CatRepository : GenericRepository<int>, ICatRepository
    {
        public CatRepository(CatDbContext context) : base(context)
        {
        }

        public async Task<Cat> GetCatById(int id)
        {
            return await this.GetEntity<Cat>().FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
