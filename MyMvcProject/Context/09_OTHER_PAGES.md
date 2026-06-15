# Other Page Views

## Views/About/Index.cshtml
```html
@{
    ViewData["Title"] = "About";
    ViewData["Description"] = "Learn more about Faleel H - AI .NET Full Stack Developer. Education, skills, and professional journey.";
}

<!-- About Hero -->
<section class="page-hero about-hero">
    <div class="container">
        <div class="page-header" data-aos="fade-up">
            <span class="page-subtitle">Get to Know Me</span>
            <h1 class="page-title">About <span class="text-gradient">Me</span></h1>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a asp-controller="Home" asp-action="Index">Home</a></li>
                    <li class="breadcrumb-item active" aria-current="page">About</li>
                </ol>
            </nav>
        </div>
    </div>
</section>

<!-- About Content -->
<section class="about-content">
    <div class="container">
        <div class="row">
            <!-- Left Column - Main Content -->
            <div class="col-lg-8">
                <!-- My Journey -->
                <div class="about-block" data-aos="fade-up">
                    <h2 class="block-title"><i class="fa-solid fa-road"></i> My Journey</h2>
                    <div class="about-text">
                        <p>
                            I'm <strong>Faleel H</strong>, a passionate AI .NET Full Stack Developer based in 
                            <strong>Thiruvarur, Tamil Nadu, India</strong>. Currently pursuing my 
                            <strong>Bachelor of Computer Application (BCA)</strong> at 
                            <strong>Bharathidasan University</strong> (2023-2026), I've dedicated my academic 
                            journey to mastering the intersection of artificial intelligence and enterprise web development.
                        </p>
                        <p>
                            Through hands-on personal projects, I've built production-ready applications that solve 
                            real-world problems. My approach combines solid software engineering fundamentals with 
                            cutting-edge AI capabilities — creating systems that are not just functional, but intelligent.
                        </p>
                    </div>
                </div>

                <!-- Why AI + .NET -->
                <div class="about-block" data-aos="fade-up" data-aos-delay="100">
                    <h2 class="block-title"><i class="fa-solid fa-lightbulb"></i> Why AI + .NET?</h2>
                    <div class="about-text">
                        <p>
                            I believe the convergence of traditional enterprise architecture and modern AI creates 
                            the most impactful software. While billion-parameter LLMs grab headlines, I focus on 
                            <strong>practical SLM implementations</strong> that deliver real business value — faster, 
                            cheaper, and fully private.
                        </p>
                        <blockquote class="about-quote">
                            "The best AI solution isn't the biggest model — it's the one that solves the problem 
                            efficiently within your constraints."
                        </blockquote>
                        <p>
                            My expertise in <strong>RAG (Retrieval-Augmented Generation)</strong>, 
                            <strong>Microsoft Agent Framework</strong>, and <strong>local LLM deployment</strong> 
                            enables me to build AI systems that enterprises can actually deploy without worrying 
                            about data privacy or API costs.
                        </p>
                    </div>
                </div>

                <!-- Education -->
                <div class="about-block" data-aos="fade-up" data-aos-delay="200">
                    <h2 class="block-title"><i class="fa-solid fa-graduation-cap"></i> Education</h2>
                    <div class="education-card">
                        <div class="education-icon">
                            <i class="fa-solid fa-university"></i>
                        </div>
                        <div class="education-details">
                            <h4>Bharathidasan University</h4>
                            <p class="degree">Bachelor of Computer Application (BCA)</p>
                            <p class="duration"><i class="fa-regular fa-calendar"></i> June 2023 — May 2026</p>
                            <p class="location"><i class="fa-solid fa-location-dot"></i> Thiruvarur, Tamil Nadu</p>
                        </div>
                    </div>
                </div>

                <!-- Core Competencies -->
                <div class="about-block" data-aos="fade-up" data-aos-delay="300">
                    <h2 class="block-title"><i class="fa-solid fa-star"></i> Core Competencies</h2>
                    <div class="competencies-grid">
                        <div class="competency-card">
                            <div class="competency-icon">
                                <i class="fa-solid fa-arrows-rotate"></i>
                            </div>
                            <h5>Adaptability</h5>
                            <p>Quickly learning and adapting to new technologies and frameworks</p>
                        </div>
                        <div class="competency-card">
                            <div class="competency-icon">
                                <i class="fa-solid fa-bullseye"></i>
                            </div>
                            <h5>Disciplined & Self-Motivated</h5>
                            <p>Driven to deliver quality work without constant supervision</p>
                        </div>
                        <div class="competency-card">
                            <div class="competency-icon">
                                <i class="fa-solid fa-magnifying-glass"></i>
                            </div>
                            <h5>Attention to Detail</h5>
                            <p>Writing clean, maintainable, and well-documented code</p>
                        </div>
                        <div class="competency-card">
                            <div class="competency-icon">
                                <i class="fa-solid fa-clock"></i>
                            </div>
                            <h5>Time Management</h5>
                            <p>Efficiently prioritizing tasks and meeting deadlines</p>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Right Column - Sidebar -->
            <div class="col-lg-4">
                <!-- Profile Card -->
                <div class="profile-card" data-aos="fade-left">
                    <div class="profile-image-wrapper">
                        <img src="~/images/hero/profile-photo.jpg" alt="Faleel H" class="profile-image" />
                        <div class="profile-glow"></div>
                    </div>
                    <h3 class="profile-name">Faleel H</h3>
                    <p class="profile-title">AI .NET Full Stack Developer</p>

                    <div class="profile-info">
                        <div class="info-item">
                            <i class="fa-solid fa-location-dot"></i>
                            <span>Thiruvarur, Tamil Nadu, India</span>
                        </div>
                        <div class="info-item">
                            <i class="fa-solid fa-envelope"></i>
                            <a href="mailto:faleelmr4@gmail.com">faleelmr4@gmail.com</a>
                        </div>
                        <div class="info-item">
                            <i class="fa-solid fa-phone"></i>
                            <a href="tel:+919790933818">+91 9790933818</a>
                        </div>
                        <div class="info-item">
                            <i class="fa-brands fa-linkedin"></i>
                            <a href="https://linkedin.com/in/faleel-h-81b8a2357" target="_blank">LinkedIn Profile</a>
                        </div>
                    </div>

                    <div class="profile-languages">
                        <h6><i class="fa-solid fa-language"></i> Languages</h6>
                        <div class="language-item">
                            <span class="language-name">English</span>
                            <span class="language-level proficient">Proficient</span>
                        </div>
                        <div class="language-item">
                            <span class="language-name">Tamil</span>
                            <span class="language-level native">Native</span>
                        </div>
                    </div>

                    <a href="~/files/Faleel_resume.pdf" class="btn btn-gradient btn-download" download>
                        <i class="fa-solid fa-download"></i> Download Resume
                    </a>
                </div>
            </div>
        </div>
    </div>
</section>
```

## Views/Contact/Index.cshtml
```html
@model Portfolio.Models.ViewModels.ContactFormViewModel

@{
    ViewData["Title"] = "Contact";
    ViewData["Description"] = "Get in touch with Faleel H. Let's discuss your project, collaboration, or job opportunity.";
}

<!-- Contact Hero -->
<section class="page-hero contact-hero">
    <div class="container">
        <div class="page-header" data-aos="fade-up">
            <span class="page-subtitle">Let's Connect</span>
            <h1 class="page-title">Get in <span class="text-gradient">Touch</span></h1>
            <p class="page-description">Have a project in mind or want to collaborate? Reach out.</p>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a asp-controller="Home" asp-action="Index">Home</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Contact</li>
                </ol>
            </nav>
        </div>
    </div>
</section>

<!-- Contact Content -->
<section class="contact-content">
    <div class="container">
        <div class="row">
            <!-- Left - Contact Form -->
            <div class="col-lg-7">
                <div class="contact-form-card" data-aos="fade-right">
                    <h3 class="form-title"><i class="fa-solid fa-paper-plane"></i> Send a Message</h3>

                    @if (TempData["SuccessMessage"] != null)
                    {
                        <div class="alert alert-success alert-dismissible fade show" role="alert">
                            <i class="fa-solid fa-circle-check"></i> @TempData["SuccessMessage"]
                            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                        </div>
                    }

                    @if (TempData["WarningMessage"] != null)
                    {
                        <div class="alert alert-warning alert-dismissible fade show" role="alert">
                            <i class="fa-solid fa-triangle-exclamation"></i> @TempData["WarningMessage"]
                            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                        </div>
                    }

                    <form asp-controller="Contact" asp-action="Submit" method="post" class="contact-form" novalidate>
                        @Html.AntiForgeryToken()

                        <div class="form-floating mb-4">
                            <input asp-for="Name" class="form-control" id="contactName" placeholder="Your Name" required />
                            <label asp-for="Name"><i class="fa-solid fa-user"></i> Your Name</label>
                            <span asp-validation-for="Name" class="text-danger"></span>
                        </div>

                        <div class="form-floating mb-4">
                            <input asp-for="Email" type="email" class="form-control" id="contactEmail" placeholder="your@email.com" required />
                            <label asp-for="Email"><i class="fa-solid fa-envelope"></i> Your Email</label>
                            <span asp-validation-for="Email" class="text-danger"></span>
                        </div>

                        <div class="form-floating mb-4">
                            <textarea asp-for="Message" class="form-control" id="contactMessage" placeholder="Your Message" style="height: 150px" required></textarea>
                            <label asp-for="Message"><i class="fa-solid fa-message"></i> Your Message</label>
                            <span asp-validation-for="Message" class="text-danger"></span>
                        </div>

                        <button type="submit" class="btn btn-gradient btn-lg w-100" id="submitBtn">
                            <span class="btn-text"><i class="fa-solid fa-paper-plane"></i> Send Message</span>
                            <span class="btn-loading d-none">
                                <i class="fa-solid fa-circle-notch fa-spin"></i> Sending...
                            </span>
                        </button>

                        <p class="privacy-note">
                            <i class="fa-solid fa-shield-halved"></i> Your information is safe. No spam, ever.
                        </p>
                    </form>
                </div>
            </div>

            <!-- Right - Contact Info -->
            <div class="col-lg-5">
                <div class="contact-info-wrapper" data-aos="fade-left">
                    <h3 class="info-title">Direct Contact</h3>

                    <div class="contact-info-card">
                        <div class="info-icon email-icon">
                            <i class="fa-solid fa-envelope"></i>
                        </div>
                        <div class="info-details">
                            <h5>Email</h5>
                            <a href="mailto:faleelmr4@gmail.com">faleelmr4@gmail.com</a>
                            <span class="response-time"><i class="fa-solid fa-clock"></i> Response within 24h</span>
                        </div>
                    </div>

                    <div class="contact-info-card">
                        <div class="info-icon phone-icon">
                            <i class="fa-solid fa-phone"></i>
                        </div>
                        <div class="info-details">
                            <h5>Phone</h5>
                            <a href="tel:+919790933818">+91 9790933818</a>
                        </div>
                    </div>

                    <div class="contact-info-card">
                        <div class="info-icon location-icon">
                            <i class="fa-solid fa-location-dot"></i>
                        </div>
                        <div class="info-details">
                            <h5>Location</h5>
                            <p>Thiruvarur, Tamil Nadu, India</p>
                        </div>
                    </div>

                    <div class="contact-info-card">
                        <div class="info-icon linkedin-icon">
                            <i class="fa-brands fa-linkedin-in"></i>
                        </div>
                        <div class="info-details">
                            <h5>LinkedIn</h5>
                            <a href="https://linkedin.com/in/faleel-h-81b8a2357" target="_blank">
                                linkedin.com/in/faleel-h-81b8a2357
                            </a>
                        </div>
                    </div>
                </div>

                <!-- Decorative Element -->
                <div class="contact-decoration" data-aos="zoom-in" data-aos-delay="200">
                    <div class="decoration-circle"></div>
                    <div class="decoration-dots"></div>
                </div>
            </div>
        </div>
    </div>
</section>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
    <script>
        // Form submission loading state
        document.querySelector('.contact-form').addEventListener('submit', function() {
            const btn = document.getElementById('submitBtn');
            btn.querySelector('.btn-text').classList.add('d-none');
            btn.querySelector('.btn-loading').classList.remove('d-none');
            btn.disabled = true;
        });
    </script>
}
```

## Views/Courses/Index.cshtml
```html
@model List<Portfolio.Models.ViewModels.CourseViewModel>

@{
    ViewData["Title"] = "Courses";
    ViewData["Description"] = "Curated courses and tutorials on C#, .NET, Angular, AI, and emerging technologies.";
}

<!-- Courses Hero -->
<section class="page-hero courses-hero">
    <div class="container">
        <div class="page-header" data-aos="fade-up">
            <span class="page-subtitle">Learning Resources</span>
            <h1 class="page-title">My <span class="text-gradient">Courses</span></h1>
            <p class="page-description">Curated courses and tutorials I've found valuable</p>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a asp-controller="Home" asp-action="Index">Home</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Courses</li>
                </ol>
            </nav>
        </div>
    </div>
</section>

<!-- Courses Grid -->
<section class="courses-content">
    <div class="container">
        <div class="courses-grid">
            @foreach (var course in Model)
            {
                <div class="course-card" data-aos="fade-up" data-aos-delay="100">
                    <a href="@course.YouTubeLink" target="_blank" class="course-link">
                        <div class="course-thumbnail-wrapper">
                            <img src="@(course.ThumbnailUrl ?? "/images/youtube-placeholder.jpg")" 
                                 alt="@course.Title" 
                                 class="course-thumbnail"
                                 loading="lazy"
                                 onerror="this.src='/images/youtube-placeholder.jpg'" />
                            <div class="course-overlay">
                                <div class="play-button">
                                    <i class="fa-solid fa-play"></i>
                                </div>
                                <div class="youtube-badge">
                                    <i class="fa-brands fa-youtube"></i> YouTube
                                </div>
                            </div>
                            @if (!string.IsNullOrEmpty(course.Duration))
                            {
                                <span class="course-duration">@course.Duration</span>
                            }
                        </div>
                        <div class="course-info">
                            <h4 class="course-title">@course.Title</h4>
                            @if (!string.IsNullOrEmpty(course.Description))
                            {
                                <p class="course-description">@course.Description</p>
                            }
                            <div class="course-meta">
                                <span class="watch-text">Watch on YouTube <i class="fa-solid fa-arrow-up-right-from-square"></i></span>
                            </div>
                        </div>
                    </a>
                </div>
            }
        </div>

        <!-- Add Course Button (Admin) -->
        <div class="text-center mt-5">
            <button class="btn btn-add-item" data-bs-toggle="modal" data-bs-target="#addCourseModal">
                <i class="fa-solid fa-plus"></i> Add New Course
            </button>
        </div>
    </div>
</section>
```

## Views/Blog/Index.cshtml
```html
@model List<Portfolio.Models.ViewModels.BlogPostViewModel>

@{
    ViewData["Title"] = "Blog";
    ViewData["Description"] = "Insights and updates on C#, .NET, Angular, AI, and emerging technologies for developers.";
}

<!-- Blog Hero -->
<section class="page-hero blog-hero">
    <div class="container">
        <div class="page-header" data-aos="fade-up">
            <span class="page-subtitle">Insights & Updates</span>
            <h1 class="page-title">Developer <span class="text-gradient">Blog</span></h1>
            <p class="page-description">Thoughts on C#, .NET, Angular, AI, and emerging tech</p>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a asp-controller="Home" asp-action="Index">Home</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Blog</li>
                </ol>
            </nav>
        </div>
    </div>
</section>

<!-- Blog Content -->
<section class="blog-content">
    <div class="container">
        <div class="blog-grid-full">
            @foreach (var post in Model)
            {
                <article class="blog-card-full" data-aos="fade-up" data-aos-delay="100">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="blog-image-wrapper">
                                @if (!string.IsNullOrEmpty(post.ImagePaths))
                                {
                                    var firstImage = post.ImagePaths.Split(',', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
                                    <img src="@(firstImage ?? "/images/placeholder-blog.jpg")" 
                                         alt="@post.Title" 
                                         class="blog-image" 
                                         loading="lazy" />
                                }
                                else
                                {
                                    <img src="/images/placeholder-blog.jpg" 
                                         alt="@post.Title" 
                                         class="blog-image" />
                                }
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="blog-content-inner">
                                @if (!string.IsNullOrEmpty(post.Tags))
                                {
                                    <div class="blog-tags">
                                        @foreach (var tag in post.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).Take(3))
                                        {
                                            <span class="blog-tag">#@tag.Trim()</span>
                                        }
                                    </div>
                                }
                                <h3 class="blog-title">@post.Title</h3>
                                <p class="blog-excerpt">@post.Description</p>
                                <div class="blog-meta">
                                    <span class="blog-date">
                                        <i class="fa-regular fa-calendar"></i> @post.PublishDate.ToString("MMMM dd, yyyy")
                                    </span>
                                    @if (!string.IsNullOrEmpty(post.ExternalLink))
                                    {
                                        <a href="@post.ExternalLink" target="_blank" class="read-more-link">
                                            Read More <i class="fa-solid fa-arrow-right"></i>
                                        </a>
                                    }
                                </div>
                            </div>
                        </div>
                    </div>
                </article>
            }
        </div>

        <!-- Add Blog Button (Admin) -->
        <div class="text-center mt-5">
            <button class="btn btn-add-item" data-bs-toggle="modal" data-bs-target="#addBlogModal">
                <i class="fa-solid fa-plus"></i> Add New Blog Post
            </button>
        </div>
    </div>
</section>
```

## Views/Projects/Index.cshtml
```html
@model List<Portfolio.Models.ViewModels.ProjectViewModel>

@{
    ViewData["Title"] = "Projects";
    ViewData["Description"] = "Explore Faleel H's portfolio of AI and .NET projects. Enterprise RAG systems, full-stack web applications, and more.";
}

<!-- Projects Hero -->
<section class="page-hero projects-hero">
    <div class="container">
        <div class="page-header" data-aos="fade-up">
            <span class="page-subtitle">Portfolio</span>
            <h1 class="page-title">My <span class="text-gradient">Projects</span></h1>
            <p class="page-description">Real-world applications built with AI and .NET</p>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a asp-controller="Home" asp-action="Index">Home</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Projects</li>
                </ol>
            </nav>
        </div>
    </div>
</section>

<!-- Projects Grid -->
<section class="projects-content">
    <div class="container">
        <div class="projects-grid-full">
            @foreach (var project in Model)
            {
                <div class="project-card-full @(project.IsFeatured ? "featured" : "")" data-aos="fade-up" data-aos-delay="100">
                    @if (project.IsFeatured)
                    {
                        <div class="featured-ribbon">
                            <i class="fa-solid fa-star"></i> Featured
                        </div>
                    }
                    <div class="row align-items-center">
                        <div class="col-lg-6">
                            <div class="project-image-wrapper">
                                <img src="@(string.IsNullOrEmpty(project.ImagePath) ? "/images/placeholder-project.jpg" : project.ImagePath)" 
                                     alt="@project.Title" 
                                     class="project-image" 
                                     loading="lazy" />
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
                        </div>
                        <div class="col-lg-6">
                            <div class="project-content">
                                <h3 class="project-title">@project.Title</h3>
                                <p class="project-description">@project.Description</p>

                                @if (!string.IsNullOrEmpty(project.ResultHighlight))
                                {
                                    <div class="result-badge">
                                        <i class="fa-solid fa-bolt"></i> @project.ResultHighlight
                                    </div>
                                }

                                @if (!string.IsNullOrEmpty(project.TechStack))
                                {
                                    <div class="tech-tags">
                                        @foreach (var tech in project.TechStack.Split(',', StringSplitOptions.RemoveEmptyEntries))
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
        </div>

        <!-- Add Project Button (Admin) -->
        <div class="text-center mt-5">
            <button class="btn btn-add-item" data-bs-toggle="modal" data-bs-target="#addProjectModal">
                <i class="fa-solid fa-plus"></i> Add New Project
            </button>
        </div>
    </div>
</section>
```
