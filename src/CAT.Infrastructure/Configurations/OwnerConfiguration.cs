using CAT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CAT.Infrastructure.Configurations
{
    internal sealed class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owners");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasColumnType("VARCHAR(20)");
            builder.Property(c => c.Address).IsRequired().HasColumnType("VARCHAR(20)");
            builder.HasMany(c => c.Cats);
        }
    }
}
