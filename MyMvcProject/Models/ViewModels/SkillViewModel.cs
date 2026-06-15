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
