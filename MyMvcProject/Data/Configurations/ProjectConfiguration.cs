using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Models.Entities;

namespace Portfolio.Data.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(p => p.ImagePath)
                .HasMaxLength(500);

            builder.Property(p => p.GitHubLink)
                .HasMaxLength(500);

            builder.Property(p => p.HostedLink)
                .HasMaxLength(500);

            builder.Property(p => p.TechStack)
                .HasMaxLength(500);

            builder.Property(p => p.ResultHighlight)
                .HasMaxLength(500);

            builder.Property(p => p.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasIndex(p => p.IsFeatured);
        }
    }
}
