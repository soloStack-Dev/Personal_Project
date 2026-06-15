using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.Entities;
using Portfolio.Models.ViewModels;
using Portfolio.Services;

namespace Portfolio.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IYouTubeService _youTubeService;
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(ApplicationDbContext context, IYouTubeService youTubeService, ILogger<CoursesController> logger)
        {
            _context = context;
            _youTubeService = youTubeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var courses = await _context.Courses
                .OrderByDescending(c => c.CreatedDate)
                .Select(c => new CourseViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    YouTubeLink = c.YouTubeLink,
                    ThumbnailUrl = c.ThumbnailUrl,
                    Description = c.Description,
                    Duration = c.Duration
                })
                .ToListAsync();

            return View(courses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_youTubeService.IsValidYouTubeUrl(model.YouTubeLink))
            {
                return Json(new { success = false, message = "Invalid YouTube URL." });
            }

            try
            {
                var videoId = _youTubeService.ExtractVideoId(model.YouTubeLink);
                var thumbnailUrl = _youTubeService.GetThumbnailUrl(videoId, "maxresdefault");

                var course = new Course
                {
                    Title = model.Title,
                    YouTubeLink = model.YouTubeLink,
                    ThumbnailUrl = thumbnailUrl,
                    Description = model.Description,
                    Duration = model.Duration,
                    CreatedDate = DateTime.UtcNow
                };

                _context.Courses.Add(course);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Course created: {CourseTitle}", course.Title);
                return Json(new { success = true, message = "Course added successfully!", courseId = course.Id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating course");
                return Json(new { success = false, message = "Failed to add course. Please try again." });
            }
        }
    }
}
