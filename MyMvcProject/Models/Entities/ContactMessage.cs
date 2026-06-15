using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.Entities
{
    public class ContactMessage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(4000)]
        public string Message { get; set; } = string.Empty;

        public DateTime SentDate { get; set; } = DateTime.UtcNow;

        public bool IsRead { get; set; } = false;

        public bool IsReplied { get; set; } = false;

        [StringLength(500)]
        public string? IpAddress { get; set; }
    }
}
