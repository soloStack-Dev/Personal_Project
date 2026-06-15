# Controllers (Controllers/)

## HomeController.cs
```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.ViewModels;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _context.Projects
                .OrderByDescending(p => p.CreatedDate)
                .Take(6)
                .Select(p => new ProjectViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    ImagePath = p.ImagePath,
                    GitHubLink = p.GitHubLink,
                    HostedLink = p.HostedLink,
                    TechStack = p.TechStack,
                    IsFeatured = p.IsFeatured,
                    ResultHighlight = p.ResultHighlight
                })
                .ToListAsync();

            var skills = await _context.Skills
                .OrderBy(s => s.Category)
                .ThenByDescending(s => s.ProficiencyLevel)
                .Select(s => new SkillViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Category = s.Category,
                    ResourceLink = s.ResourceLink,
                    ProficiencyLevel = s.ProficiencyLevel,
                    IconClass = s.IconClass
                })
                .ToListAsync();

            var blogPosts = await _context.BlogPosts
                .Where(b => b.IsPublished)
                .OrderByDescending(b => b.PublishDate)
                .Take(3)
                .Select(b => new BlogPostViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    ImagePaths = b.ImagePaths,
                    Tags = b.Tags,
                    PublishDate = b.PublishDate
                })
                .ToListAsync();

            var viewModel = new HomeViewModel
            {
                Projects = projects,
                Skills = skills,
                BlogPosts = blogPosts,
                FeaturedProject = projects.FirstOrDefault(p => p.IsFeatured)
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
```

## AboutController.cs
```csharp
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
```

## ProjectsController.cs
```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.Entities;
using Portfolio.Models.ViewModels;
using Portfolio.Services;

namespace Portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageService _imageService;
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(ApplicationDbContext context, IImageService imageService, ILogger<ProjectsController> logger)
        {
            _context = context;
            _imageService = imageService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var projects = await _context.Projects
                .OrderByDescending(p => p.IsFeatured)
                .ThenByDescending(p => p.CreatedDate)
                .Select(p => new ProjectViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    ImagePath = p.ImagePath,
                    GitHubLink = p.GitHubLink,
                    HostedLink = p.HostedLink,
                    TechStack = p.TechStack,
                    IsFeatured = p.IsFeatured,
                    ResultHighlight = p.ResultHighlight
                })
                .ToListAsync();

            return View(projects);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                string? imagePath = null;
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    imagePath = await _imageService.SaveImageAsync(model.ImageFile, "projects");
                }

                var project = new Project
                {
                    Title = model.Title,
                    Description = model.Description,
                    ImagePath = imagePath,
                    GitHubLink = model.GitHubLink,
                    HostedLink = model.HostedLink,
                    TechStack = model.TechStack,
                    IsFeatured = model.IsFeatured,
                    ResultHighlight = model.ResultHighlight,
                    CreatedDate = DateTime.UtcNow
                };

                _context.Projects.Add(project);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Project created: {ProjectTitle}", project.Title);
                return Json(new { success = true, message = "Project added successfully!", projectId = project.Id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating project");
                return Json(new { success = false, message = "Failed to add project. Please try again." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
                return NotFound();

            return Json(new
            {
                project.Id,
                project.Title,
                project.Description,
                project.ImagePath,
                project.GitHubLink,
                project.HostedLink,
                project.TechStack,
                project.IsFeatured,
                project.ResultHighlight
            });
        }
    }
}
```

## SkillsController.cs
```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.Entities;
using Portfolio.Models.ViewModels;

namespace Portfolio.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SkillsController> _logger;

        public SkillsController(ApplicationDbContext context, ILogger<SkillsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var skills = await _context.Skills
                .OrderBy(s => s.Category)
                .ThenByDescending(s => s.ProficiencyLevel)
                .Select(s => new SkillViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Category = s.Category,
                    ResourceLink = s.ResourceLink,
                    ProficiencyLevel = s.ProficiencyLevel,
                    IconClass = s.IconClass
                })
                .ToListAsync();

            return View(skills);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SkillViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var skill = new Skill
                {
                    Name = model.Name,
                    Category = model.Category,
                    ResourceLink = model.ResourceLink,
                    ProficiencyLevel = model.ProficiencyLevel,
                    IconClass = model.IconClass ?? "fa-solid fa-code",
                    CreatedDate = DateTime.UtcNow
                };

                _context.Skills.Add(skill);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Skill created: {SkillName}", skill.Name);
                return Json(new { success = true, message = "Skill added successfully!", skillId = skill.Id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating skill");
                return Json(new { success = false, message = "Failed to add skill. Please try again." });
            }
        }
    }
}
```

## CoursesController.cs
```csharp
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
```

## BlogController.cs
```csharp
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
```

## ContactController.cs
```csharp
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models.Entities;
using Portfolio.Models.ViewModels;
using Portfolio.Services;

namespace Portfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(ApplicationDbContext context, IEmailService emailService, ILogger<ContactController> logger)
        {
            _context = context;
            _emailService = emailService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ContactFormViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            try
            {
                // Save to database
                var contactMessage = new ContactMessage
                {
                    Name = model.Name,
                    Email = model.Email,
                    Message = model.Message,
                    SentDate = DateTime.UtcNow,
                    IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString()
                };

                _context.ContactMessages.Add(contactMessage);
                await _context.SaveChangesAsync();

                // Send email notification
                var emailSent = await _emailService.SendContactNotificationAsync(
                    model.Name, 
                    model.Email, 
                    model.Message
                );

                if (emailSent)
                {
                    TempData["SuccessMessage"] = "Thank you! Your message has been sent successfully. I'll get back to you soon.";
                    _logger.LogInformation("Contact form submitted and email sent from {Email}", model.Email);
                }
                else
                {
                    TempData["WarningMessage"] = "Your message was saved, but there was an issue sending the notification email. I'll still receive your message.";
                    _logger.LogWarning("Contact form saved but email failed from {Email}", model.Email);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing contact form from {Email}", model.Email);
                ModelState.AddModelError("", "An error occurred while sending your message. Please try again later.");
                return View("Index", model);
            }
        }
    }
}
```

## AdminController.cs (Optional - For Admin Dashboard)
```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;

namespace Portfolio.Controllers
{
    // [Authorize] // Uncomment when adding authentication
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AdminController> _logger;

        public AdminController(ApplicationDbContext context, ILogger<AdminController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Dashboard()
        {
            var stats = new
            {
                TotalProjects = await _context.Projects.CountAsync(),
                TotalSkills = await _context.Skills.CountAsync(),
                TotalCourses = await _context.Courses.CountAsync(),
                TotalBlogPosts = await _context.BlogPosts.CountAsync(),
                TotalMessages = await _context.ContactMessages.CountAsync(),
                UnreadMessages = await _context.ContactMessages.CountAsync(m => !m.IsRead)
            };

            return View(stats);
        }

        public async Task<IActionResult> Messages()
        {
            var messages = await _context.ContactMessages
                .OrderByDescending(m => m.SentDate)
                .ToListAsync();

            return View(messages);
        }

        [HttpPost]
        public async Task<IActionResult> MarkMessageAsRead(int id)
        {
            var message = await _context.ContactMessages.FindAsync(id);
            if (message != null)
            {
                message.IsRead = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Messages");
        }
    }
}
```
