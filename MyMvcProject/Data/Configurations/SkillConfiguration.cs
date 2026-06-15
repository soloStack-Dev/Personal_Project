using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Models.Entities;

namespace Portfolio.Data.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Category)
                .IsRequired();

            builder.Property(s => s.ResourceLink)
                .HasMaxLength(500);

            builder.Property(s => s.IconClass)
                .HasMaxLength(100);

            builder.Property(s => s.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasIndex(s => s.Category);
        }
    }
}
