using CAT.Application.Contracts.Result;

namespace CAT.Application.Contracts.Cats
{
    public sealed class CatResponse : IResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
