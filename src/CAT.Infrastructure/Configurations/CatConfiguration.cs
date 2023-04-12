using CAT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAT.Infrastructure.Configurations
{
    internal sealed class CatConfiguration : IEntityTypeConfiguration<Cat>
    {
        public void Configure(EntityTypeBuilder<Cat> builder)
        {
            builder.ToTable("Cats");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasColumnType("VARCHAR(20)");
            builder.Property(c => c.Age).IsRequired().HasColumnType("VARCHAR(20)");
            builder.Property(c => c.IdOwner).IsRequired();
            builder.HasOne(c => c.Owner).WithMany(o => o.Cats).HasForeignKey(c => c.IdOwner);
        }
    }
}
