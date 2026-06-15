# Entity Models (Models/Entities/)

## Project.cs
```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string? TechStack { get; set; } // Comma-separated tech tags

        public bool IsFeatured { get; set; } = false;

        [StringLength(500)]
        public string? ResultHighlight { get; set; } // e.g., "Sub-second query latency"

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDate { get; set; }
    }
}
```

## Skill.cs
```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models.Entities
{
    public enum SkillCategory
    {
        Frontend,
        Backend,
        Database,
        AI_Emerging,
        Tools
    }

    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public SkillCategory Category { get; set; }

        [StringLength(500)]
        [Url]
        public string? ResourceLink { get; set; }

        [Range(1, 100)]
        public int ProficiencyLevel { get; set; } = 50;

        [StringLength(100)]
        public string? IconClass { get; set; } // Font Awesome icon class

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
```

## Course.cs
```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        [Url]
        public string YouTubeLink { get; set; } = string.Empty;

        [StringLength(500)]
        public string? ThumbnailUrl { get; set; } // Auto-generated from YouTube URL

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? Duration { get; set; } // e.g., "2h 30m"

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Helper method to extract YouTube video ID and generate thumbnail URL
        public void GenerateThumbnailUrl()
        {
            if (string.IsNullOrEmpty(YouTubeLink)) return;

            var videoId = ExtractYouTubeVideoId(YouTubeLink);
            if (!string.IsNullOrEmpty(videoId))
            {
                ThumbnailUrl = $"https://img.youtube.com/vi/{videoId}/maxresdefault.jpg";
            }
        }

        private static string? ExtractYouTubeVideoId(string url)
        {
            // Handle various YouTube URL formats
            var patterns = new[]
            {
                @"youtube\.com/watch\?v=([^&]+)",
                @"youtu\.be/([^?]+)",
                @"youtube\.com/embed/([^?]+)",
                @"youtube\.com/v/([^?]+)"
            };

            foreach (var pattern in patterns)
            {
                var match = System.Text.RegularExpressions.Regex.Match(url, pattern);
                if (match.Success && match.Groups.Count > 1)
                {
                    return match.Groups[1].Value;
                }
            }
            return null;
        }
    }
}
```

## BlogPost.cs
```csharp
using System;
using System.Collections.Generic;
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
        public string? Content { get; set; } // HTML content from rich text editor

        [StringLength(2000)]
        public string? ImagePaths { get; set; } // Comma-separated image paths

        [StringLength(500)]
        [Url]
        public string? ExternalLink { get; set; }

        [StringLength(200)]
        public string? Tags { get; set; } // Comma-separated tags e.g., "csharp,ai,angular"

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
```

## ContactMessage.cs
```csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
```

## Database Configuration Notes
- All entities use `DateTime.UtcNow` for timestamps
- String lengths specified to optimize SQL column sizes
- Nullable properties marked with `?` for optional fields
- `NotMapped` properties for computed values (not stored in DB)
- Foreign keys: None needed for this simple portfolio (no relationships between entities)
- Indexing: Consider adding index on `Project.IsFeatured`, `BlogPost.IsPublished`, `BlogPost.PublishDate`
