using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models.Entities
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [StringLength(10000)]
        public string? Content { get; set; }

        [StringLength(2000)]
        public string? ImagePaths { get; set; }

        [StringLength(500)]
        [Url]
        public string? ExternalLink { get; set; }

        [StringLength(200)]
        public string? Tags { get; set; }

        public bool IsPublished { get; set; } = true;

        public DateTime PublishDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }

        [NotMapped]
        public List<string> ImagePathsList =>
            string.IsNullOrEmpty(ImagePaths)
                ? new List<string>()
                : new List<string>(ImagePaths.Split(',', StringSplitOptions.RemoveEmptyEntries));
    }
}
