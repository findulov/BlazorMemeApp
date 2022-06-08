using MemeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemeApp.Infrastructure.Database.Configurations
{
    internal class MemePreviewLinkConfiguration : IEntityTypeConfiguration<MemePreviewLink>
    {
        public void Configure(EntityTypeBuilder<MemePreviewLink> builder)
        {
            builder.Property(memePreviewLink => memePreviewLink.Url).IsRequired().HasMaxLength(2000);

            builder.ToTable("MemePreviewLinks");
        }
    }
}
