using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Models.Entities;

namespace Portfolio.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.YouTubeLink)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(c => c.ThumbnailUrl)
                .HasMaxLength(500);

            builder.Property(c => c.Description)
                .HasMaxLength(1000);

            builder.Property(c => c.Duration)
                .HasMaxLength(50);

            builder.Property(c => c.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
