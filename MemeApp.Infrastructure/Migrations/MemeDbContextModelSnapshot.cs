// <auto-generated />
using System;
using MemeApp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MemeApp.Infrastructure.Migrations
{
    [DbContext(typeof(MemeDbContext))]
    partial class MemeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MemeApp.Domain.Entities.Meme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsNotSafeForWork")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSpoiler")
                        .HasColumnType("bit");

                    b.Property<string>("PostLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RedditPostLikes")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("Id");

                    b.ToTable("Memes", (string)null);
                });

            modelBuilder.Entity("MemeApp.Domain.Entities.MemePreviewLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MemeId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("Id");

                    b.HasIndex("MemeId");

                    b.ToTable("MemePreviewLinks", (string)null);
                });

            modelBuilder.Entity("MemeApp.Domain.Entities.MemePreviewLink", b =>
                {
                    b.HasOne("MemeApp.Domain.Entities.Meme", "Meme")
                        .WithMany("PreviewLinks")
                        .HasForeignKey("MemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meme");
                });

            modelBuilder.Entity("MemeApp.Domain.Entities.Meme", b =>
                {
                    b.Navigation("PreviewLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
