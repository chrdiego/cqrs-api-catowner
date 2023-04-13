using CAT.Domain.Primitives;

namespace CAT.Domain.Entities
{
    public class Cat : IEntityBase<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int IdOwner { get; set; }

        public virtual Owner Owner { get; set; }
    }
}
