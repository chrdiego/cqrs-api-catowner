using System.Reflection;
using CAT.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CAT.Infrastructure.Context
{
    public class CatDbContext : DbContext
    {
        public CatDbContext(DbContextOptions<CatDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cat> Cats { get; set; }
        public DbSet<Owner> Owners { get; set; }

    }
}
