using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
