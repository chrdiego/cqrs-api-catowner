using CAT.Domain.Primitives;

namespace CAT.Domain.Entities
{
    public class Owner : IEntityBase<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Cat> Cats { get; set; }
    }
}
