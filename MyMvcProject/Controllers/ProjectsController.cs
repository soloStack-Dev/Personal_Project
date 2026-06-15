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
