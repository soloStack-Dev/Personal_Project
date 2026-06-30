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
                    new() { Name = "TanStack Query", Category = SkillCategory.Frontend, ProficiencyLevel = 65, IconClass = "fa-solid fa-code" },
                    new() { Name = "Zustand", Category = SkillCategory.Frontend, ProficiencyLevel = 60, IconClass = "fa-solid fa-cubes" },
                    new() { Name = "C#", Category = SkillCategory.Backend, ProficiencyLevel = 85, IconClass = "fa-solid fa-code" },
                    new() { Name = ".NET Core", Category = SkillCategory.Backend, ProficiencyLevel = 85, IconClass = "fa-solid fa-server" },
                    new() { Name = "Minimal API", Category = SkillCategory.Backend, ProficiencyLevel = 75, IconClass = "fa-solid fa-bolt" },
                    new() { Name = ".NET MVC", Category = SkillCategory.Backend, ProficiencyLevel = 85, IconClass = "fa-solid fa-laptop-code" },
                    new() { Name = "Git", Category = SkillCategory.Backend, ProficiencyLevel = 85, IconClass = "fa-brands fa-git-alt" },
                    new() { Name = "GitHub", Category = SkillCategory.Backend, ProficiencyLevel = 80, IconClass = "fa-brands fa-github" },
                    new() { Name = "SQL Server", Category = SkillCategory.Database, ProficiencyLevel = 75, IconClass = "fa-solid fa-database" },
                    new() { Name = "Redis", Category = SkillCategory.Database, ProficiencyLevel = 60, IconClass = "fa-solid fa-memory" },
                    new() { Name = "Entity Framework", Category = SkillCategory.Database, ProficiencyLevel = 80, IconClass = "fa-solid fa-database" },
                    new() { Name = "LLM / RAG", Category = SkillCategory.AI_Emerging, ProficiencyLevel = 70, IconClass = "fa-solid fa-brain" },
                    new() { Name = "MCP", Category = SkillCategory.AI_Emerging, ProficiencyLevel = 60, IconClass = "fa-solid fa-plug" },
                    new() { Name = "SLM", Category = SkillCategory.AI_Emerging, ProficiencyLevel = 70, IconClass = "fa-solid fa-microchip" },
                    new() { Name = "Agent CLI", Category = SkillCategory.AI_Emerging, ProficiencyLevel = 65, IconClass = "fa-solid fa-terminal" },
                    new() { Name = "Microsoft Agentic Framework", Category = SkillCategory.AI_Emerging, ProficiencyLevel = 70, IconClass = "fa-brands fa-microsoft" },
                    new() { Name = "Ollama", Category = SkillCategory.AI_Emerging, ProficiencyLevel = 70, IconClass = "fa-solid fa-robot" },
                    new() { Name = "GitHub Copilot", Category = SkillCategory.AI_Emerging, ProficiencyLevel = 75, IconClass = "fa-solid fa-wand-magic-sparkles" },
                    new() { Name = "ML", Category = SkillCategory.AI_Emerging, ProficiencyLevel = 60, IconClass = "fa-solid fa-chart-line" },
                    new() { Name = "Docker", Category = SkillCategory.Tools, ProficiencyLevel = 65, IconClass = "fa-brands fa-docker" }
                };
                context.Skills.AddRange(skills);
            }

            if (!context.Projects.Any())
            {
                var projects = new List<Project>
                {
                    new()
                    {
                        Title = "Enterprise Agentic RAG System",
                        Description = "Built a local, enterprise-grade RAG system using Small Language Models (SLMs) that delivers sub-second responses for proprietary knowledge retrieval. Architected full-stack solution with Angular frontend, .NET Web API backend, Ollama-hosted SLMs, Microsoft Agent Framework, Redis caching, and EF Core for data persistence. Achieved sub-second query latency on internal documents, proving SLMs outperform general LLMs for focused enterprise use cases while ensuring complete data privacy.",
                        TechStack = "Angular,TypeScript,C#,.NET Web API,Ollama,Redis,EF Core,Microsoft Agent Framework",
                        IsFeatured = true,
                        ResultHighlight = "Sub-second query latency achieved",
                        GitHubLink = "https://github.com/soloStack-Dev",
                        ImagePath = "/images/project_img.jpeg"
                    },
                    new()
                    {
                        Title = "Health Agent",
                        Description = "A full-stack health agent application with a .NET backend API and Angular client. Features intelligent health query processing, user management, and real-time data processing capabilities. The server provides robust API endpoints while the client delivers a modern, responsive user interface.",
                        TechStack = "Angular,TypeScript,C#,.NET Web API,Entity Framework,SQL Server",
                        GitHubLink = "https://github.com/soloStack-Dev/HealthAgent_client.git",
                        HostedLink = "https://healthagent-client.onrender.com/",
                        ImagePath = "/images/project_two.png",
                        ResultHighlight = "Full-stack health intelligence platform"
                    }
                };
                context.Projects.AddRange(projects);
            }

            await context.SaveChangesAsync();
        }
    }
}
