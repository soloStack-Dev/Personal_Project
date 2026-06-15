using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(2000)]
        public string Description { get; set; } = string.Empty;

        [StringLength(500)]
        public string? ImagePath { get; set; }

        [StringLength(500)]
        [Url]
        public string? GitHubLink { get; set; }

        [StringLength(500)]
        [Url]
        public string? HostedLink { get; set; }

        [StringLength(500)]
        public string? TechStack { get; set; }

        public bool IsFeatured { get; set; } = false;

        [StringLength(500)]
        public string? ResultHighlight { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }
    }
}
