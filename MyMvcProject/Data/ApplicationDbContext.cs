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

            modelBuilder.ApplyConfiguration(new Configurations.ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.SkillConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.CourseConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.BlogPostConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ContactMessageConfiguration());
        }
    }
}
