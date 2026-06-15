using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Models.Entities;

namespace Portfolio.Data.Configurations
{
    public class ContactMessageConfiguration : IEntityTypeConfiguration<ContactMessage>
    {
        public void Configure(EntityTypeBuilder<ContactMessage> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Message)
                .IsRequired()
                .HasMaxLength(4000);

            builder.Property(c => c.IpAddress)
                .HasMaxLength(500);

            builder.Property(c => c.SentDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasIndex(c => c.SentDate);
            builder.HasIndex(c => c.IsRead);
        }
    }
}
