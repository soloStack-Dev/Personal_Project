using Portfolio.Models.ViewModels;

namespace Portfolio.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<ProjectViewModel> Projects { get; set; } = new();
        public List<SkillViewModel> Skills { get; set; } = new();
        public List<BlogPostViewModel> BlogPosts { get; set; } = new();
        public ProjectViewModel? FeaturedProject { get; set; }
    }
}
