using CAT.Domain.Entities;
using CAT.Domain.Primitives;

namespace CAT.Domain.Repository
{
    public interface ICatRepository : IGenericRepository<int>
    {
        Task<Cat> GetCatById(int id);
    }
}
