# Shared Views (Views/Shared/)

## _Layout.cshtml
```html
<!DOCTYPE html>
<html lang="en" data-theme="dark">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"] - Faleel H | AI .NET Full Stack Developer</title>

    <!-- Meta Tags -->
    <meta name="description" content="@ViewData["Description"]" />
    <meta name="author" content="Faleel H" />
    <meta name="keywords" content=".NET, C#, Angular, AI, Full Stack Developer, RAG, LLM, Portfolio" />

    <!-- Open Graph -->
    <meta property="og:title" content="@ViewData["Title"] - Faleel H" />
    <meta property="og:description" content="@ViewData["Description"]" />
    <meta property="og:type" content="website" />
    <meta property="og:url" content="https://faleelh.dev" />
    <meta property="og:image" content="https://faleelh.dev/images/og-image.jpg" />

    <!-- Twitter Card -->
    <meta name="twitter:card" content="summary_large_image" />
    <meta name="twitter:title" content="@ViewData["Title"] - Faleel H" />
    <meta name="twitter:description" content="@ViewData["Description"]" />
    <meta name="twitter:image" content="https://faleelh.dev/images/og-image.jpg" />

    <!-- Favicon -->
    <link rel="icon" type="image/x-icon" href="~/favicon.ico" />

    <!-- Google Fonts -->
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&family=JetBrains+Mono:wght@400;500&display=swap" rel="stylesheet" />

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" />

    <!-- AOS Animation Library -->
    <link href="https://unpkg.com/aos@2.3.1/dist/aos.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link rel="stylesheet" href="~/css/site.css" asp-append-version="true" />
    <link rel="stylesheet" href="~/css/light-theme.css" asp-append-version="true" />
    <link rel="stylesheet" href="~/css/animations.css" asp-append-version="true" />

    @await RenderSectionAsync("Styles", required: false)
</head>
<body>
    <!-- Navigation -->
    <partial name="_Navigation" />

    <!-- Main Content -->
    <main role="main">
        @RenderBody()
    </main>

    <!-- Footer -->
    <partial name="_Footer" />

    <!-- Admin Modals (Hidden by default) -->
    <partial name="_AdminModals" />

    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>

    <!-- AOS Animation -->
    <script src="https://unpkg.com/aos@2.3.1/dist/aos.js"></script>

    <!-- Custom Scripts -->
    <script src="~/js/theme-toggle.js" asp-append-version="true"></script>
    <script src="~/js/admin-modals.js" asp-append-version="true"></script>
    <script src="~/js/site.js" asp-append-version="true"></script>

    <script>
        // Initialize AOS
        AOS.init({
            duration: 800,
            easing: 'ease-out-cubic',
            once: true,
            offset: 100
        });
    </script>

    @await RenderSectionAsync("Scripts", required: false)
</body>
</html>
```

## _Navigation.cshtml
```html
@using Portfolio.Models.Entities

<nav class="navbar navbar-expand-lg fixed-top" id="mainNav">
    <div class="container">
        <!-- Logo -->
        <a class="navbar-brand" href="~/">
            <span class="logo-text">FH<span class="logo-dot">.</span></span>
        </a>

        <!-- Mobile Toggle -->
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" 
                aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <!-- Navigation Links -->
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav mx-auto">
                <li class="nav-item">
                    <a class="nav-link @(ViewContext.RouteData.Values["controller"]?.ToString() == "Home" ? "active" : "")" 
                       asp-controller="Home" asp-action="Index">Home</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link @(ViewContext.RouteData.Values["controller"]?.ToString() == "About" ? "active" : "")" 
                       asp-controller="About" asp-action="Index">About</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link @(ViewContext.RouteData.Values["controller"]?.ToString() == "Projects" ? "active" : "")" 
                       asp-controller="Projects" asp-action="Index">Projects</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link @(ViewContext.RouteData.Values["controller"]?.ToString() == "Skills" ? "active" : "")" 
                       asp-controller="Skills" asp-action="Index">Skills</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link @(ViewContext.RouteData.Values["controller"]?.ToString() == "Blog" ? "active" : "")" 
                       asp-controller="Blog" asp-action="Index">Blog</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link @(ViewContext.RouteData.Values["controller"]?.ToString() == "Courses" ? "active" : "")" 
                       asp-controller="Courses" asp-action="Index">Courses</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link @(ViewContext.RouteData.Values["controller"]?.ToString() == "Contact" ? "active" : "")" 
                       asp-controller="Contact" asp-action="Index">Contact</a>
                </li>
            </ul>

            <!-- Right Side Actions -->
            <div class="nav-actions d-flex align-items-center gap-3">
                <!-- Theme Toggle -->
                <button class="theme-toggle-btn" id="themeToggle" aria-label="Toggle theme">
                    <i class="fa-solid fa-sun" id="themeIcon"></i>
                </button>

                <!-- Resume Button -->
                <a href="~/files/Faleel_resume.pdf" class="btn btn-resume" target="_blank" download>
                    Resume
                </a>
            </div>
        </div>
    </div>
</nav>

<!-- Spacer for fixed navbar -->
<div class="navbar-spacer"></div>
```

## _Footer.cshtml
```html
<footer class="site-footer">
    <div class="container">
        <div class="row footer-content">
            <!-- Brand Column -->
            <div class="col-lg-4 col-md-6 mb-4 mb-lg-0">
                <div class="footer-brand">
                    <span class="logo-text">FH<span class="logo-dot">.</span></span>
                    <p class="footer-tagline">Building intelligent systems with .NET and AI</p>
                </div>
                <div class="footer-social">
                    <a href="https://linkedin.com/in/faleel-h-81b8a2357" target="_blank" class="social-link" aria-label="LinkedIn">
                        <i class="fa-brands fa-linkedin-in"></i>
                    </a>
                    <a href="https://github.com/faleelh" target="_blank" class="social-link" aria-label="GitHub">
                        <i class="fa-brands fa-github"></i>
                    </a>
                    <a href="mailto:faleelmr4@gmail.com" class="social-link" aria-label="Email">
                        <i class="fa-solid fa-envelope"></i>
                    </a>
                    <a href="tel:+919790933818" class="social-link" aria-label="Phone">
                        <i class="fa-solid fa-phone"></i>
                    </a>
                </div>
            </div>

            <!-- Quick Links -->
            <div class="col-lg-2 col-md-6 mb-4 mb-lg-0">
                <h5 class="footer-heading">Quick Links</h5>
                <ul class="footer-links">
                    <li><a asp-controller="Home" asp-action="Index">Home</a></li>
                    <li><a asp-controller="About" asp-action="Index">About</a></li>
                    <li><a asp-controller="Projects" asp-action="Index">Projects</a></li>
                    <li><a asp-controller="Skills" asp-action="Index">Skills</a></li>
                    <li><a asp-controller="Blog" asp-action="Index">Blog</a></li>
                    <li><a asp-controller="Contact" asp-action="Index">Contact</a></li>
                </ul>
            </div>

            <!-- Tech Stack -->
            <div class="col-lg-3 col-md-6 mb-4 mb-lg-0">
                <h5 class="footer-heading">Tech Stack</h5>
                <div class="footer-tags">
                    <span class="tech-tag">C#</span>
                    <span class="tech-tag">.NET</span>
                    <span class="tech-tag">Angular</span>
                    <span class="tech-tag">AI</span>
                    <span class="tech-tag">RAG</span>
                    <span class="tech-tag">SQL</span>
                    <span class="tech-tag">Redis</span>
                    <span class="tech-tag">Docker</span>
                </div>
            </div>

            <!-- Contact Info -->
            <div class="col-lg-3 col-md-6">
                <h5 class="footer-heading">Get in Touch</h5>
                <div class="footer-contact">
                    <p><i class="fa-solid fa-envelope"></i> faleelmr4@gmail.com</p>
                    <p><i class="fa-solid fa-phone"></i> +91 9790933818</p>
                    <p><i class="fa-solid fa-location-dot"></i> Thiruvarur, Tamil Nadu, India</p>
                </div>
            </div>
        </div>

        <!-- Bottom Bar -->
        <div class="footer-bottom">
            <div class="row align-items-center">
                <div class="col-md-6">
                    <p class="copyright">&copy; 2026 Faleel H. Crafted with C# .NET MVC & passion.</p>
                </div>
                <div class="col-md-6 text-md-end">
                    <a href="#" class="back-to-top" id="backToTop">
                        Back to top <i class="fa-solid fa-arrow-up"></i>
                    </a>
                </div>
            </div>
        </div>
    </div>
</footer>
```

## _AdminModals.cshtml
```html
@using Portfolio.Models.Entities

<!-- Add Project Modal -->
<div class="modal fade admin-modal" id="addProjectModal" tabindex="-1" aria-labelledby="addProjectModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="addProjectModalLabel">
                    <i class="fa-solid fa-plus-circle"></i> Add New Project
                </h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <form id="addProjectForm" enctype="multipart/form-data">
                @Html.AntiForgeryToken()
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="projectTitle" class="form-label">Project Title *</label>
                        <input type="text" class="form-control" id="projectTitle" name="Title" required maxlength="200" placeholder="Enter project name">
                    </div>
                    <div class="mb-3">
                        <label for="projectDescription" class="form-label">Description *</label>
                        <textarea class="form-control" id="projectDescription" name="Description" rows="4" required maxlength="2000" placeholder="Describe your project..."></textarea>
                    </div>
                    <div class="mb-3">
                        <label for="projectImage" class="form-label">Project Image</label>
                        <div class="file-upload-zone" id="projectImageZone">
                            <input type="file" class="form-control" id="projectImage" name="ImageFile" accept=".jpg,.jpeg,.png,.gif,.webp">
                            <div class="upload-placeholder">
                                <i class="fa-solid fa-cloud-arrow-up"></i>
                                <span>Drag & drop or click to upload</span>
                                <small>Max 5MB (JPG, PNG, GIF, WebP)</small>
                            </div>
                            <div class="upload-preview d-none">
                                <img src="" alt="Preview" class="preview-image" />
                                <button type="button" class="btn-remove-file"><i class="fa-solid fa-times"></i></button>
                            </div>
                        </div>
                    </div>
                    <div class="mb-3">
                        <label for="projectGitHub" class="form-label">GitHub Link</label>
                        <input type="url" class="form-control" id="projectGitHub" name="GitHubLink" placeholder="https://github.com/username/repo">
                    </div>
                    <div class="mb-3">
                        <label for="projectHosted" class="form-label">Live Demo Link</label>
                        <input type="url" class="form-control" id="projectHosted" name="HostedLink" placeholder="https://your-project.com">
                    </div>
                    <div class="mb-3">
                        <label for="projectTechStack" class="form-label">Tech Stack (comma-separated)</label>
                        <input type="text" class="form-control" id="projectTechStack" name="TechStack" placeholder="C#, Angular, SQL Server, Redis">
                    </div>
                    <div class="mb-3">
                        <label for="projectResult" class="form-label">Result Highlight</label>
                        <input type="text" class="form-control" id="projectResult" name="ResultHighlight" placeholder="e.g., Sub-second query latency achieved">
                    </div>
                    <div class="form-check mb-3">
                        <input class="form-check-input" type="checkbox" id="projectFeatured" name="IsFeatured">
                        <label class="form-check-label" for="projectFeatured">Mark as Featured Project</label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                    <button type="submit" class="btn btn-primary btn-gradient">
                        <i class="fa-solid fa-plus"></i> Add Project
                    </button>
                </div>
            </form>
        </div>
    </div>
</div>

<!-- Add Skill Modal -->
<div class="modal fade admin-modal" id="addSkillModal" tabindex="-1" aria-labelledby="addSkillModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="addSkillModalLabel">
                    <i class="fa-solid fa-plus-circle"></i> Add New Skill
                </h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <form id="addSkillForm">
                @Html.AntiForgeryToken()
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="skillName" class="form-label">Skill Name *</label>
                        <input type="text" class="form-control" id="skillName" name="Name" required maxlength="100" placeholder="e.g., React, Python, Docker">
                    </div>
                    <div class="mb-3">
                        <label for="skillCategory" class="form-label">Category *</label>
                        <select class="form-select" id="skillCategory" name="Category" required>
                            <option value="">Select Category</option>
                            <option value="Frontend">Frontend</option>
                            <option value="Backend">Backend</option>
                            <option value="Database">Database</option>
                            <option value="AI_Emerging">AI & Emerging</option>
                            <option value="Tools">Tools</option>
                        </select>
                    </div>
                    <div class="mb-3">
                        <label for="skillResource" class="form-label">Learning Resource Link</label>
                        <input type="url" class="form-control" id="skillResource" name="ResourceLink" placeholder="https://docs.microsoft.com/...">
                    </div>
                    <div class="mb-3">
                        <label for="skillProficiency" class="form-label">Proficiency Level: <span id="proficiencyValue">50</span>%</label>
                        <input type="range" class="form-range" id="skillProficiency" name="ProficiencyLevel" min="1" max="100" value="50">
                    </div>
                    <div class="mb-3">
                        <label for="skillIcon" class="form-label">Icon Class (Font Awesome)</label>
                        <input type="text" class="form-control" id="skillIcon" name="IconClass" value="fa-solid fa-code" placeholder="fa-brands fa-react">
                        <small class="form-text">Find icons at fontawesome.com/icons</small>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                    <button type="submit" class="btn btn-primary btn-gradient">
                        <i class="fa-solid fa-plus"></i> Add Skill
                    </button>
                </div>
            </form>
        </div>
    </div>
</div>

<!-- Add Course Modal -->
<div class="modal fade admin-modal" id="addCourseModal" tabindex="-1" aria-labelledby="addCourseModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="addCourseModalLabel">
                    <i class="fa-solid fa-plus-circle"></i> Add New Course
                </h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <form id="addCourseForm">
                @Html.AntiForgeryToken()
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="courseTitle" class="form-label">Course Title *</label>
                        <input type="text" class="form-control" id="courseTitle" name="Title" required maxlength="200" placeholder="e.g., C# Beginner Crash Course">
                    </div>
                    <div class="mb-3">
                        <label for="courseYouTube" class="form-label">YouTube Link *</label>
                        <input type="url" class="form-control" id="courseYouTube" name="YouTubeLink" required placeholder="https://youtube.com/watch?v=...">
                        <small class="form-text">Thumbnail will be auto-generated from this link</small>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Thumbnail Preview</label>
                        <div class="thumbnail-preview-container">
                            <img id="courseThumbnailPreview" src="/images/youtube-placeholder.jpg" alt="Thumbnail Preview" class="thumbnail-preview" />
                        </div>
                    </div>
                    <div class="mb-3">
                        <label for="courseDescription" class="form-label">Description</label>
                        <textarea class="form-control" id="courseDescription" name="Description" rows="3" maxlength="1000" placeholder="Brief description of the course..."></textarea>
                    </div>
                    <div class="mb-3">
                        <label for="courseDuration" class="form-label">Duration</label>
                        <input type="text" class="form-control" id="courseDuration" name="Duration" placeholder="e.g., 2h 30m">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                    <button type="submit" class="btn btn-primary btn-gradient">
                        <i class="fa-solid fa-plus"></i> Add Course
                    </button>
                </div>
            </form>
        </div>
    </div>
</div>

<!-- Add Blog Post Modal -->
<div class="modal fade admin-modal" id="addBlogModal" tabindex="-1" aria-labelledby="addBlogModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="addBlogModalLabel">
                    <i class="fa-solid fa-plus-circle"></i> Add New Blog Post
                </h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <form id="addBlogForm" enctype="multipart/form-data">
                @Html.AntiForgeryToken()
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="blogTitle" class="form-label">Blog Title *</label>
                        <input type="text" class="form-control" id="blogTitle" name="Title" required maxlength="200" placeholder="Enter blog post title">
                    </div>
                    <div class="mb-3">
                        <label for="blogDescription" class="form-label">Short Description *</label>
                        <textarea class="form-control" id="blogDescription" name="Description" rows="3" required maxlength="500" placeholder="Brief summary of the post..."></textarea>
                    </div>
                    <div class="mb-3">
                        <label for="blogContent" class="form-label">Content (HTML)</label>
                        <textarea class="form-control" id="blogContent" name="Content" rows="8" placeholder="Write your blog content (supports HTML)..."></textarea>
                    </div>
                    <div class="mb-3">
                        <label for="blogImages" class="form-label">Blog Images</label>
                        <div class="file-upload-zone" id="blogImageZone">
                            <input type="file" class="form-control" id="blogImages" name="ImageFiles" accept=".jpg,.jpeg,.png,.gif,.webp" multiple>
                            <div class="upload-placeholder">
                                <i class="fa-solid fa-cloud-arrow-up"></i>
                                <span>Drag & drop or click to upload multiple images</span>
                                <small>Max 5MB each (JPG, PNG, GIF, WebP)</small>
                            </div>
                            <div class="upload-preview-grid d-none" id="blogPreviewGrid"></div>
                        </div>
                    </div>
                    <div class="mb-3">
                        <label for="blogExternalLink" class="form-label">External Link</label>
                        <input type="url" class="form-control" id="blogExternalLink" name="ExternalLink" placeholder="https://...">
                    </div>
                    <div class="mb-3">
                        <label for="blogTags" class="form-label">Tags (comma-separated)</label>
                        <input type="text" class="form-control" id="blogTags" name="Tags" placeholder="csharp, angular, ai, tutorial">
                    </div>
                    <div class="form-check mb-3">
                        <input class="form-check-input" type="checkbox" id="blogPublish" name="IsPublished" value="true" checked>
                        <label class="form-check-label" for="blogPublish">Publish immediately</label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                    <button type="submit" class="btn btn-primary btn-gradient">
                        <i class="fa-solid fa-plus"></i> Add Blog Post
                    </button>
                </div>
            </form>
        </div>
    </div>
</div>

<!-- Toast Notification Container -->
<div class="toast-container position-fixed bottom-0 end-0 p-3" id="toastContainer">
    <div id="liveToast" class="toast" role="alert" aria-live="assertive" aria-atomic="true">
        <div class="toast-header">
            <i class="fa-solid fa-circle-check text-success me-2" id="toastIcon"></i>
            <strong class="me-auto" id="toastTitle">Notification</strong>
            <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
        </div>
        <div class="toast-body" id="toastMessage">
            Operation completed successfully!
        </div>
    </div>
</div>
```

## _ValidationScriptsPartial.cshtml
```html
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.20.0/jquery.validate.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/4.0.0/jquery.validate.unobtrusive.min.js"></script>
```
