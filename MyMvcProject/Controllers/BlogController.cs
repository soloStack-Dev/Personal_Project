using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.Entities;
using Portfolio.Models.ViewModels;
using Portfolio.Services;

namespace Portfolio.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageService _imageService;
        private readonly ILogger<BlogController> _logger;

        public BlogController(ApplicationDbContext context, IImageService imageService, ILogger<BlogController> logger)
        {
            _context = context;
            _imageService = imageService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var posts = await _context.BlogPosts
                .Where(b => b.IsPublished)
                .OrderByDescending(b => b.PublishDate)
                .Select(b => new BlogPostViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Content = b.Content,
                    ImagePaths = b.ImagePaths,
                    ExternalLink = b.ExternalLink,
                    Tags = b.Tags,
                    PublishDate = b.PublishDate
                })
                .ToListAsync();

            return View(posts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var imagePaths = new List<string>();
                if (model.ImageFiles != null && model.ImageFiles.Any())
                {
                    imagePaths = await _imageService.SaveImagesAsync(model.ImageFiles, "blog");
                }

                var blogPost = new BlogPost
                {
                    Title = model.Title,
                    Description = model.Description,
                    Content = model.Content,
                    ImagePaths = imagePaths.Any() ? string.Join(",", imagePaths) : null,
                    ExternalLink = model.ExternalLink,
                    Tags = model.Tags,
                    IsPublished = model.IsPublished,
                    PublishDate = DateTime.UtcNow
                };

                _context.BlogPosts.Add(blogPost);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Blog post created: {BlogTitle}", blogPost.Title);
                return Json(new { success = true, message = "Blog post added successfully!", postId = blogPost.Id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating blog post");
                return Json(new { success = false, message = "Failed to add blog post. Please try again." });
            }
        }
    }
}
