# Database Context & Configuration (Data/)

## ApplicationDbContext.cs
```csharp
using Microsoft.EntityFrameworkCore;
using Portfolio.Models.Entities;

namespace Portfolio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply entity configurations
            modelBuilder.ApplyConfiguration(new Configurations.ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.SkillConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.CourseConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.BlogPostConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ContactMessageConfiguration());
        }
    }
}
```

## Data/Configurations/ProjectConfiguration.cs
```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Models.Entities;

namespace Portfolio.Data.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(p => p.ImagePath)
                .HasMaxLength(500);

            builder.Property(p => p.GitHubLink)
                .HasMaxLength(500);

            builder.Property(p => p.HostedLink)
                .HasMaxLength(500);

            builder.Property(p => p.TechStack)
                .HasMaxLength(500);

            builder.Property(p => p.ResultHighlight)
                .HasMaxLength(500);

            builder.Property(p => p.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasIndex(p => p.IsFeatured);
        }
    }
}
```

## Data/Configurations/SkillConfiguration.cs
```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Models.Entities;

namespace Portfolio.Data.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Category)
                .IsRequired();

            builder.Property(s => s.ResourceLink)
                .HasMaxLength(500);

            builder.Property(s => s.IconClass)
                .HasMaxLength(100);

            builder.Property(s => s.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasIndex(s => s.Category);
        }
    }
}
```

## Data/Configurations/CourseConfiguration.cs
```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Models.Entities;

namespace Portfolio.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.YouTubeLink)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(c => c.ThumbnailUrl)
                .HasMaxLength(500);

            builder.Property(c => c.Description)
                .HasMaxLength(1000);

            builder.Property(c => c.Duration)
                .HasMaxLength(50);

            builder.Property(c => c.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
```

## Data/Configurations/BlogPostConfiguration.cs
```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Models.Entities;

namespace Portfolio.Data.Configurations
{
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.Content)
                .HasMaxLength(10000);

            builder.Property(b => b.ImagePaths)
                .HasMaxLength(2000);

            builder.Property(b => b.ExternalLink)
                .HasMaxLength(500);

            builder.Property(b => b.Tags)
                .HasMaxLength(200);

            builder.Property(b => b.PublishDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasIndex(b => b.IsPublished);
            builder.HasIndex(b => b.PublishDate);
        }
    }
}
```

## Data/Configurations/ContactMessageConfiguration.cs
```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Models.Entities;

namespace Portfolio.Data.Configurations
{
    public class ContactMessageConfiguration : IEntityTypeConfiguration<ContactMessage>
    {
        public void Configure(EntityTypeBuilder<ContactMessage> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Message)
                .IsRequired()
                .HasMaxLength(4000);

            builder.Property(c => c.IpAddress)
                .HasMaxLength(500);

            builder.Property(c => c.SentDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasIndex(c => c.SentDate);
            builder.HasIndex(c => c.IsRead);
        }
    }
}
```

## Program.cs Configuration
```csharp
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add Serilog logging
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/portfolio-.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container
builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add custom services
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IYouTubeService, YouTubeService>();

// Add HttpClient for external API calls
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ensure database is created and migrations applied
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();

    // Seed initial data if empty
    await DbSeeder.SeedAsync(dbContext);
}

app.Run();
```

## Data/DbSeeder.cs (Optional Initial Data)
```csharp
using Portfolio.Models.Entities;

namespace Portfolio.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // Seed Skills if none exist
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

            // Seed Featured Project if none exist
            if (!context.Projects.Any())
            {
                var project = new Project
                {
                    Title = "Enterprise Agentic RAG System",
                    Description = "Built a local, enterprise-grade RAG system using Small Language Models (SLMs) that delivers sub-second responses for proprietary knowledge retrieval. Architected full-stack solution with Angular frontend, .NET Web API backend, Ollama-hosted SLMs, Microsoft Agent Framework, Redis caching, and EF Core for data persistence. Achieved sub-second query latency on internal documents, proving SLMs outperform general LLMs for focused enterprise use cases while ensuring complete data privacy.",
                    TechStack = "Angular,TypeScript,C#,.NET Web API,Ollama,Redis,EF Core,Microsoft Agent Framework",
                    IsFeatured = true,
                    ResultHighlight = "Sub-second query latency achieved",
                    GitHubLink = "https://github.com/faleelh/enterprise-rag-system",
                    ImagePath = "/images/projects/rag-system.jpg"
                };
                context.Projects.Add(project);
            }

            await context.SaveChangesAsync();
        }
    }
}
```

## EF Core Migrations Commands
```bash
# Add initial migration
dotnet ef migrations add InitialCreate

# Update database
dotnet ef database update

# Add subsequent migration after model changes
dotnet ef migrations add AddedNewField
```
