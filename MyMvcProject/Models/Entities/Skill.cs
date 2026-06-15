using System.ComponentModel.DataAnnotations;

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
        public string? IconClass { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
