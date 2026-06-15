using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Models.Entities;

namespace Portfolio.Data.Configurations
{
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.Content)
                .HasMaxLength(10000);

            builder.Property(b => b.ImagePaths)
                .HasMaxLength(2000);

            builder.Property(b => b.ExternalLink)
                .HasMaxLength(500);

            builder.Property(b => b.Tags)
                .HasMaxLength(200);

            builder.Property(b => b.PublishDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasIndex(b => b.IsPublished);
            builder.HasIndex(b => b.PublishDate);
        }
    }
}
