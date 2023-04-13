namespace CAT.Domain.Primitives
{
    public interface IEntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
