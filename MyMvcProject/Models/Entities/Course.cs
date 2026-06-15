using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
        public string? ThumbnailUrl { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? Duration { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

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
            var patterns = new[]
            {
                @"youtube\.com/watch\?v=([^&]+)",
                @"youtu\.be/([^?]+)",
                @"youtube\.com/embed/([^?]+)",
                @"youtube\.com/v/([^?]+)"
            };

            foreach (var pattern in patterns)
            {
                var match = Regex.Match(url, pattern);
                if (match.Success && match.Groups.Count > 1)
                {
                    return match.Groups[1].Value;
                }
            }
            return null;
        }
    }
}
