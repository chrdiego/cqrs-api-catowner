using CAT.Domain.Entities;
using CAT.Domain.Primitives;

namespace CAT.Domain.Repository
{
    public interface ICatRepository : IGenericRepository<int>
    {
        Task<List<Cat>> GetCats();
        Task<Cat> GetCatById(int id);
    }
}
