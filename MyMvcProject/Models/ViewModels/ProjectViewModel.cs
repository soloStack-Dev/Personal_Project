using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Project title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        [Display(Name = "Project Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters")]
        [Display(Name = "Project Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Project Image")]
        [AllowedExtensions(new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" })]
        [MaxFileSize(5 * 1024 * 1024)]
        public IFormFile? ImageFile { get; set; }

        [StringLength(500)]
        [Url(ErrorMessage = "Please enter a valid URL")]
        [Display(Name = "GitHub Link")]
        public string? GitHubLink { get; set; }

        [StringLength(500)]
        [Url(ErrorMessage = "Please enter a valid URL")]
        [Display(Name = "Live Demo Link")]
        public string? HostedLink { get; set; }

        [StringLength(500)]
        [Display(Name = "Tech Stack (comma-separated)")]
        public string? TechStack { get; set; }

        [Display(Name = "Featured Project")]
        public bool IsFeatured { get; set; }

        [StringLength(500)]
        [Display(Name = "Result Highlight")]
        public string? ResultHighlight { get; set; }

        public string? ImagePath { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
