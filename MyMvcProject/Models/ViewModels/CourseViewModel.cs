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
