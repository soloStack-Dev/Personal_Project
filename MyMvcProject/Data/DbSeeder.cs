using Portfolio.Models.Entities;

namespace Portfolio.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Skills.Any())
            {
                var skills = new List<Skill>
                {
                    new() { Name = "HTML5", Category = SkillCategory.Frontend, ProficiencyLevel = 90, IconClass = "fa-brands fa-html5" },
                    new() { Name = "CSS3", Category = SkillCategory.Frontend, ProficiencyLevel = 85, IconClass = "fa-brands fa-css3-alt" },
                    new() { Name = "JavaScript", Category = SkillCategory.Frontend, ProficiencyLevel = 80, IconClass = "fa-brands fa-js" },
                    new() { Name = "TypeScript", Category = SkillCategory.Frontend, ProficiencyLevel = 75, IconClass = "fa-brands fa-js" },
                    new() { Name = "Angular", Category = SkillCategory.Frontend, ProficiencyLevel = 70, IconClass = "fa-brands fa-angular" },
                    new() { Name = "C#", Category = SkillCategory.Backend, ProficiencyLevel = 85, IconClass = "fa-solid fa-code" },
                    new() { Name = ".NET Core", Category = SkillCategory.Backend, ProficiencyLevel = 80, IconClass = "fa-solid fa-server" },
                    new() { Name = ".NET MVC", Category = SkillCategory.Backend, ProficiencyLevel = 85, IconClass = "fa-solid fa-laptop-code" },
                    new() { Name = "SQL Server", Category = SkillCategory.Database, ProficiencyLevel = 75, IconClass = "fa-solid fa-database" },
                    new() { Name = "Redis", Category = SkillCategory.Database, ProficiencyLevel = 60, IconClass = "fa-solid fa-memory" },
                    new() { Name = "Entity Framework", Category = SkillCategory.Database, ProficiencyLevel = 80, IconClass = "fa-solid fa-database" },
                    new() { Name = "LLM / RAG", Category = SkillCategory.AI_Emerging, ProficiencyLevel = 70, IconClass = "fa-solid fa-brain" },
                    new() { Name = "Git", Category = SkillCategory.Tools, ProficiencyLevel = 85, IconClass = "fa-brands fa-git-alt" },
                    new() { Name = "Docker", Category = SkillCategory.Tools, ProficiencyLevel = 65, IconClass = "fa-brands fa-docker" }
                };
                context.Skills.AddRange(skills);
            }

            if (!context.Projects.Any())
            {
                var project = new Project
                {
                    Title = "Enterprise Agentic RAG System",
                    Description = "Built a local, enterprise-grade RAG system using Small Language Models (SLMs) that delivers sub-second responses for proprietary knowledge retrieval. Architected full-stack solution with Angular frontend, .NET Web API backend, Ollama-hosted SLMs, Microsoft Agent Framework, Redis caching, and EF Core for data persistence. Achieved sub-second query latency on internal documents, proving SLMs outperform general LLMs for focused enterprise use cases while ensuring complete data privacy.",
                    TechStack = "Angular,TypeScript,C#,.NET Web API,Ollama,Redis,EF Core,Microsoft Agent Framework",
                    IsFeatured = true,
                    ResultHighlight = "Sub-second query latency achieved",
                    GitHubLink = "https://github.com/soloStack-Dev",
                    ImagePath = "/images/project_img.jpeg"
                };
                context.Projects.Add(project);
            }

            await context.SaveChangesAsync();
        }
    }
}
