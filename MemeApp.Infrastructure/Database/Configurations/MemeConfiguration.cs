using MemeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemeApp.Infrastructure.Database.Configurations
{
    internal class MemeConfiguration : IEntityTypeConfiguration<Meme>
    {
        public void Configure(EntityTypeBuilder<Meme> builder)
        {
            builder.Property(meme => meme.Title).IsRequired().HasMaxLength(200);
            builder.Property(meme => meme.Url).IsRequired().HasMaxLength(2000);
            builder.Property(meme => meme.Author).IsRequired().HasMaxLength(100);

            builder.ToTable("Memes");
        }
    }
}
