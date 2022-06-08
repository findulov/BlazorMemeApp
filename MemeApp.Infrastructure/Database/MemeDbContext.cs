using MemeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace MemeApp.Infrastructure.Database
{
    public class MemeDbContext : DbContext
    {
        public MemeDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Meme> Memes { get; set; }

        public DbSet<MemePreviewLink> MemePreviewLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
