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
