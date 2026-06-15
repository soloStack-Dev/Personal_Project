# Home Page View (Views/Home/Index.cshtml)

```html
@model Portfolio.Models.ViewModels.HomeViewModel

@{
    ViewData["Title"] = "Home";
    ViewData["Description"] = "Faleel H - AI .NET Full Stack Developer. Building intelligent web applications with C#, Angular, and modern AI frameworks.";
}

<!-- Hero Section -->
<section class="hero-section" id="home">
    <div class="container">
        <div class="row align-items-center min-vh-100">
            <!-- Left Content -->
            <div class="col-lg-6" data-aos="fade-right" data-aos-duration="1000">
                <div class="hero-content">
                    <!-- Availability Badge -->
                    <div class="availability-badge">
                        <span class="pulse-dot"></span>
                        Available for Opportunities
                    </div>

                    <!-- Name -->
                    <h1 class="hero-name">
                        FALEEL<span class="name-highlight"> H</span>
                    </h1>

                    <!-- Title with Typing Animation -->
                    <div class="hero-title-wrapper">
                        <span class="hero-title-prefix">I'm a </span>
                        <span class="hero-title" id="typingText">AI .NET Full Stack Developer</span>
                        <span class="typing-cursor">|</span>
                    </div>

                    <!-- Description -->
                    <p class="hero-description">
                        Building intelligent web applications at the intersection of AI and .NET. 
                        I specialize in creating agentic systems, RAG-based document intelligence, 
                        and scalable full-stack solutions using Angular, C#, and modern AI frameworks.
                    </p>

                    <!-- Unique Thought Quote -->
                    <blockquote class="hero-quote">
                        <i class="fa-solid fa-quote-left quote-icon"></i>
                        The future of enterprise software isn't just faster code — it's systems that 
                        think, learn, and adapt. I bridge traditional .NET architecture with emerging 
                        AI: SLMs, agent frameworks, and contextual retrieval.
                    </blockquote>

                    <!-- CTA Buttons -->
                    <div class="hero-cta">
                        <a href="#projects" class="btn btn-primary btn-lg btn-gradient">
                            <i class="fa-solid fa-rocket"></i> View My Work
                        </a>
                        <a asp-controller="Contact" asp-action="Index" class="btn btn-outline-primary btn-lg">
                            <i class="fa-solid fa-paper-plane"></i> Contact Me
                        </a>
                    </div>

                    <!-- Stats Row -->
                    <div class="hero-stats">
                        <div class="stat-item">
                            <span class="stat-number">5+</span>
                            <span class="stat-label">Projects</span>
                        </div>
                        <div class="stat-divider"></div>
                        <div class="stat-item">
                            <span class="stat-number">AI</span>
                            <span class="stat-label">& .NET Focus</span>
                        </div>
                        <div class="stat-divider"></div>
                        <div class="stat-item">
                            <span class="stat-number">BCA</span>
                            <span class="stat-label">2026</span>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Right Visual -->
            <div class="col-lg-6" data-aos="fade-left" data-aos-duration="1000" data-aos-delay="200">
                <div class="hero-visual">
                    <div class="hero-image-wrapper">
                        <div class="hero-glow"></div>
                        <img src="~/images/hero/developer-portrait.png" 
                             alt="Faleel H - AI .NET Developer" 
                             class="hero-image" />

                        <!-- Floating Code Snippets -->
                        <div class="floating-code code-1">
                            <code><span class="code-keyword">class</span> <span class="code-class">Developer</span> { ... }</code>
                        </div>
                        <div class="floating-code code-2">
                            <code><span class="code-keyword">await</span> <span class="code-method">BuildAsync</span>();</code>
                        </div>
                        <div class="floating-code code-3">
                            <code><span class="code-keyword">var</span> ai = <span class="code-string">"RAG"</span>;</code>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Scroll Indicator -->
    <div class="scroll-indicator">
        <div class="mouse">
            <div class="wheel"></div>
        </div>
        <span>Scroll Down</span>
    </div>
</section>

<!-- Skills Section -->
<section class="skills-section" id="skills">
    <div class="container">
        <div class="section-header" data-aos="fade-up">
            <span class="section-subtitle">My Expertise</span>
            <h2 class="section-title">Technical <span class="text-gradient">Arsenal</span></h2>
            <p class="section-description">Technologies I use to build intelligent systems</p>
        </div>

        <div class="skills-grid">
            @foreach (var category in Model.Skills.GroupBy(s => s.Category).OrderBy(g => g.Key))
            {
                <div class="skill-category" data-aos="fade-up" data-aos-delay="@(Array.IndexOf(Model.Skills.GroupBy(s => s.Category).OrderBy(g => g.Key).ToArray(), category) * 100)">
                    <div class="category-header">
                        <span class="category-badge">@category.Key.ToString().Replace("_", " & ")</span>
                    </div>
                    <div class="skill-cards">
                        @foreach (var skill in category.OrderByDescending(s => s.ProficiencyLevel))
                        {
                            <div class="skill-card">
                                <div class="skill-icon">
                                    <i class="@(skill.IconClass ?? "fa-solid fa-code")"></i>
                                </div>
                                <div class="skill-info">
                                    <h5 class="skill-name">@skill.Name</h5>
                                    <div class="skill-progress">
                                        <div class="progress-bar">
                                            <div class="progress-fill" style="width: @skill.ProficiencyLevel%" data-width="@skill.ProficiencyLevel"></div>
                                        </div>
                                        <span class="skill-percent">@skill.ProficiencyLevel%</span>
                                    </div>
                                </div>
                                @if (!string.IsNullOrEmpty(skill.ResourceLink))
                                {
                                    <a href="@skill.ResourceLink" target="_blank" class="skill-link" title="Learn more">
                                        <i class="fa-solid fa-arrow-up-right-from-square"></i>
                                    </a>
                                }
                            </div>
                        }
                    </div>
                </div>
            }
        </div>

        <!-- Add Skill Button (Admin) -->
        <div class="text-center mt-4">
            <button class="btn btn-add-item" data-bs-toggle="modal" data-bs-target="#addSkillModal">
                <i class="fa-solid fa-plus"></i> Add New Skill
            </button>
        </div>
    </div>
</section>

<!-- Projects Section -->
<section class="projects-section" id="projects">
    <div class="container">
        <div class="section-header" data-aos="fade-up">
            <span class="section-subtitle">Portfolio</span>
            <h2 class="section-title">Featured <span class="text-gradient">Projects</span></h2>
            <p class="section-description">Real-world applications built with AI and .NET</p>
        </div>

        <!-- Featured Project (Full Width) -->
        @if (Model.FeaturedProject != null)
        {
            <div class="featured-project" data-aos="fade-up">
                <div class="featured-badge">
                    <i class="fa-solid fa-star"></i> Featured
                </div>
                <div class="row align-items-center">
                    <div class="col-lg-7">
                        <div class="project-image-wrapper">
                            <img src="@(string.IsNullOrEmpty(Model.FeaturedProject.ImagePath) ? "/images/placeholder-project.jpg" : Model.FeaturedProject.ImagePath)" 
                                 alt="@Model.FeaturedProject.Title" 
                                 class="project-image" />
                            <div class="project-overlay">
                                <div class="project-links">
                                    @if (!string.IsNullOrEmpty(Model.FeaturedProject.GitHubLink))
                                    {
                                        <a href="@Model.FeaturedProject.GitHubLink" target="_blank" class="project-link">
                                            <i class="fa-brands fa-github"></i>
                                        </a>
                                    }
                                    @if (!string.IsNullOrEmpty(Model.FeaturedProject.HostedLink))
                                    {
                                        <a href="@Model.FeaturedProject.HostedLink" target="_blank" class="project-link">
                                            <i class="fa-solid fa-arrow-up-right-from-square"></i>
                                        </a>
                                    }
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-5">
                        <div class="project-content">
                            <h3 class="project-title">@Model.FeaturedProject.Title</h3>
                            <p class="project-description">@Model.FeaturedProject.Description</p>

                            @if (!string.IsNullOrEmpty(Model.FeaturedProject.ResultHighlight))
                            {
                                <div class="result-badge">
                                    <i class="fa-solid fa-bolt"></i> @Model.FeaturedProject.ResultHighlight
                                </div>
                            }

                            @if (!string.IsNullOrEmpty(Model.FeaturedProject.TechStack))
                            {
                                <div class="tech-tags">
                                    @foreach (var tech in Model.FeaturedProject.TechStack.Split(',', StringSplitOptions.RemoveEmptyEntries))
                                    {
                                        <span class="tech-tag">@tech.Trim()</span>
                                    }
                                </div>
                            }
                        </div>
                    </div>
                </div>
            </div>
        }

        <!-- Project Grid -->
        <div class="projects-grid">
            @foreach (var project in Model.Projects.Where(p => !p.IsFeatured).Take(4))
            {
                <div class="project-card" data-aos="fade-up" data-aos-delay="100">
                    <div class="project-image-wrapper">
                        <img src="@(string.IsNullOrEmpty(project.ImagePath) ? "/images/placeholder-project.jpg" : project.ImagePath)" 
                             alt="@project.Title" 
                             class="project-image" />
                        <div class="project-overlay">
                            <div class="project-links">
                                @if (!string.IsNullOrEmpty(project.GitHubLink))
                                {
                                    <a href="@project.GitHubLink" target="_blank" class="project-link" title="View on GitHub">
                                        <i class="fa-brands fa-github"></i>
                                    </a>
                                }
                                @if (!string.IsNullOrEmpty(project.HostedLink))
                                {
                                    <a href="@project.HostedLink" target="_blank" class="project-link" title="Live Demo">
                                        <i class="fa-solid fa-arrow-up-right-from-square"></i>
                                    </a>
                                }
                            </div>
                        </div>
                    </div>
                    <div class="project-content">
                        <h4 class="project-title">@project.Title</h4>
                        <p class="project-description">@(project.Description.Length > 120 ? project.Description.Substring(0, 120) + "..." : project.Description)</p>

                        @if (!string.IsNullOrEmpty(project.TechStack))
                        {
                            <div class="tech-tags">
                                @foreach (var tech in project.TechStack.Split(',', StringSplitOptions.RemoveEmptyEntries).Take(4))
                                {
                                    <span class="tech-tag">@tech.Trim()</span>
                                }
                            </div>
                        }
                    </div>
                </div>
            }
        </div>

        <!-- Add Project Button (Admin) -->
        <div class="text-center mt-4">
            <button class="btn btn-add-item" data-bs-toggle="modal" data-bs-target="#addProjectModal">
                <i class="fa-solid fa-plus"></i> Add New Project
            </button>
        </div>
    </div>
</section>

<!-- Blog Section -->
<section class="blog-section" id="blog">
    <div class="container">
        <div class="section-header" data-aos="fade-up">
            <span class="section-subtitle">Insights</span>
            <h2 class="section-title">Latest <span class="text-gradient">Updates</span></h2>
            <p class="section-description">Thoughts on C#, .NET, Angular, AI, and emerging tech</p>
        </div>

        <div class="blog-grid">
            @foreach (var post in Model.BlogPosts)
            {
                <article class="blog-card" data-aos="fade-up" data-aos-delay="100">
                    <div class="blog-image-wrapper">
                        @if (!string.IsNullOrEmpty(post.ImagePaths))
                        {
                            var firstImage = post.ImagePaths.Split(',', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
                            <img src="@(firstImage ?? "/images/placeholder-blog.jpg")" alt="@post.Title" class="blog-image" />
                        }
                        else
                        {
                            <img src="/images/placeholder-blog.jpg" alt="@post.Title" class="blog-image" />
                        }
                        <div class="blog-overlay">
                            <span class="read-more">Read More <i class="fa-solid fa-arrow-right"></i></span>
                        </div>
                    </div>
                    <div class="blog-content">
                        @if (!string.IsNullOrEmpty(post.Tags))
                        {
                            <div class="blog-tags">
                                @foreach (var tag in post.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).Take(3))
                                {
                                    <span class="blog-tag">#@tag.Trim()</span>
                                }
                            </div>
                        }
                        <h4 class="blog-title">@post.Title</h4>
                        <p class="blog-excerpt">@post.Description</p>
                        <div class="blog-meta">
                            <span class="blog-date">
                                <i class="fa-regular fa-calendar"></i> @post.PublishDate.ToString("MMM dd, yyyy")
                            </span>
                            @if (!string.IsNullOrEmpty(post.ExternalLink))
                            {
                                <a href="@post.ExternalLink" target="_blank" class="blog-external-link">
                                    External Link <i class="fa-solid fa-arrow-up-right-from-square"></i>
                                </a>
                            }
                        </div>
                    </div>
                </article>
            }
        </div>

        <!-- Add Blog Button (Admin) -->
        <div class="text-center mt-4">
            <button class="btn btn-add-item" data-bs-toggle="modal" data-bs-target="#addBlogModal">
                <i class="fa-solid fa-plus"></i> Add New Blog Post
            </button>
        </div>
    </div>
</section>

@section Scripts {
    <script>
        // Typing animation for hero title
        const typingText = document.getElementById('typingText');
        const text = typingText.textContent;
        typingText.textContent = '';
        let charIndex = 0;

        function typeWriter() {
            if (charIndex < text.length) {
                typingText.textContent += text.charAt(charIndex);
                charIndex++;
                setTimeout(typeWriter, 100);
            }
        }

        // Start typing animation after page load
        setTimeout(typeWriter, 1000);

        // Animate skill bars on scroll
        const skillBars = document.querySelectorAll('.progress-fill');
        const animateSkillBars = () => {
            skillBars.forEach(bar => {
                const rect = bar.getBoundingClientRect();
                if (rect.top < window.innerHeight && rect.bottom >= 0) {
                    bar.style.width = bar.getAttribute('data-width') + '%';
                }
            });
        };

        window.addEventListener('scroll', animateSkillBars);
        animateSkillBars(); // Initial check
    </script>
}
```
