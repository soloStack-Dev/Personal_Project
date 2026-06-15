using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.ViewModels
{
    public class BlogPostViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Blog title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        [Display(Name = "Blog Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [Display(Name = "Short Description")]
        public string Description { get; set; } = string.Empty;

        [StringLength(10000)]
        [Display(Name = "Blog Content (HTML)")]
        public string? Content { get; set; }

        [Display(Name = "Blog Images")]
        [AllowedExtensions(new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" })]
        [MaxFileSize(5 * 1024 * 1024)]
        public List<IFormFile>? ImageFiles { get; set; }

        [StringLength(500)]
        [Url(ErrorMessage = "Please enter a valid URL")]
        [Display(Name = "External Link")]
        public string? ExternalLink { get; set; }

        [StringLength(200)]
        [Display(Name = "Tags (comma-separated)")]
        public string? Tags { get; set; }

        [Display(Name = "Publish")]
        public bool IsPublished { get; set; } = true;

        public string? ImagePaths { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
