# ViewModels (Models/ViewModels/)

## ProjectViewModel.cs
```csharp
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

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
        [MaxFileSize(5 * 1024 * 1024)] // 5MB
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
    }
}
```

## SkillViewModel.cs
```csharp
using System.ComponentModel.DataAnnotations;
using Portfolio.Models.Entities;

namespace Portfolio.Models.ViewModels
{
    public class SkillViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Skill name is required")]
        [StringLength(100, ErrorMessage = "Skill name cannot exceed 100 characters")]
        [Display(Name = "Skill Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Category")]
        public SkillCategory Category { get; set; }

        [StringLength(500)]
        [Url(ErrorMessage = "Please enter a valid URL")]
        [Display(Name = "Learning Resource Link")]
        public string? ResourceLink { get; set; }

        [Range(1, 100, ErrorMessage = "Proficiency must be between 1 and 100")]
        [Display(Name = "Proficiency Level (%)")]
        public int ProficiencyLevel { get; set; } = 50;

        [StringLength(100)]
        [Display(Name = "Font Awesome Icon Class")]
        public string? IconClass { get; set; } = "fa-solid fa-code";
    }
}
```

## CourseViewModel.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        [Display(Name = "Course Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "YouTube link is required")]
        [StringLength(500)]
        [Url(ErrorMessage = "Please enter a valid YouTube URL")]
        [Display(Name = "YouTube Link")]
        public string YouTubeLink { get; set; } = string.Empty;

        public string? ThumbnailUrl { get; set; }

        [StringLength(1000)]
        [Display(Name = "Course Description")]
        public string? Description { get; set; }

        [StringLength(50)]
        [Display(Name = "Duration")]
        public string? Duration { get; set; }
    }
}
```

## BlogPostViewModel.cs
```csharp
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

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
    }
}
```

## ContactFormViewModel.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.ViewModels
{
    public class ContactFormViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [Display(Name = "Your Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [StringLength(200, ErrorMessage = "Email cannot exceed 200 characters")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Your Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Message is required")]
        [StringLength(4000, ErrorMessage = "Message cannot exceed 4000 characters")]
        [MinLength(10, ErrorMessage = "Message must be at least 10 characters")]
        [Display(Name = "Your Message")]
        public string Message { get; set; } = string.Empty;
    }
}
```

## HomeViewModel.cs
```csharp
namespace Portfolio.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<ProjectViewModel> Projects { get; set; } = new();
        public List<SkillViewModel> Skills { get; set; } = new();
        public List<BlogPostViewModel> BlogPosts { get; set; } = new();
        public ProjectViewModel? FeaturedProject { get; set; }
    }
}
```

## Custom Validation Attributes

### AllowedExtensionsAttribute.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.ViewModels
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!_extensions.Contains(extension))
                {
                    return new ValidationResult($"Only {string.Join(", ", _extensions)} files are allowed.");
                }
            }
            else if (value is IEnumerable<IFormFile> files)
            {
                foreach (var f in files)
                {
                    var extension = Path.GetExtension(f.FileName).ToLowerInvariant();
                    if (!_extensions.Contains(extension))
                    {
                        return new ValidationResult($"Only {string.Join(", ", _extensions)} files are allowed.");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
```

### MaxFileSizeAttribute.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.ViewModels
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file && file.Length > _maxFileSize)
            {
                return new ValidationResult($"File size cannot exceed {_maxFileSize / 1024 / 1024}MB.");
            }
            else if (value is IEnumerable<IFormFile> files)
            {
                foreach (var f in files)
                {
                    if (f.Length > _maxFileSize)
                    {
                        return new ValidationResult($"File size cannot exceed {_maxFileSize / 1024 / 1024}MB.");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
```
