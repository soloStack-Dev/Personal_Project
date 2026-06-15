<div align="center">
  <img src="https://img.shields.io/badge/ASP.NET%20Core%20MVC-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="ASP.NET Core MVC 10.0"/>
  <img src="https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C# 12.0"/>
  <img src="https://img.shields.io/badge/EF%20Core-10.0-512BD4?style=for-the-badge&logo=entity-framework&logoColor=white" alt="EF Core 10.0"/>
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="SQL Server"/>
  <br/>
  <img src="https://img.shields.io/badge/Bootstrap-5.3-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white" alt="Bootstrap 5.3"/>
  <img src="https://img.shields.io/badge/SendGrid-9.29-00B4D8?style=for-the-badge&logo=sendgrid&logoColor=white" alt="SendGrid"/>
  <img src="https://img.shields.io/badge/Serilog-FFC107?style=for-the-badge&logo=serilog&logoColor=black" alt="Serilog"/>
  <img src="https://img.shields.io/badge/ImageSharp-3.1-FF6A00?style=for-the-badge" alt="ImageSharp"/>
</div>

<br/>

<div align="center">
  <h1>🚀 Faleel H — Personal Portfolio</h1>
  <p>
    <strong>A modern, feature-rich portfolio website built with ASP.NET Core MVC</strong>
  </p>
  <p>
    <a href="https://faleelh.dev">🌐 faleelh.dev</a>
    &nbsp;•&nbsp;
    <a href="#features">✨ Features</a>
    &nbsp;•&nbsp;
    <a href="#tech-stack">⚙️ Tech Stack</a>
    &nbsp;•&nbsp;
    <a href="#getting-started">🏁 Getting Started</a>
    &nbsp;•&nbsp;
    <a href="#project-structure">📁 Structure</a>
    &nbsp;•&nbsp;
    <a href="#api-endpoints">🔌 API</a>
  </p>
</div>

<br/>

---

## 📋 Overview

**Personal Portfolio** is a full-stack ASP.NET Core MVC web application showcasing the work, skills, and expertise of **Faleel H** — an AI .NET Full Stack Developer. The site serves as a dynamic digital resume featuring project galleries, skill visualizations, a blog, curated YouTube courses, and a contact form with email notifications.

> Built with .NET 10, Entity Framework Core, SQL Server, and modern frontend tooling.

---

## ✨ Features

<table>
  <tr>
    <td width="50%">
      <h3>🏠 Dynamic Home Page</h3>
      <ul>
        <li>Personal branding with typewriter effect</li>
        <li>Featured project showcase</li>
        <li>Skills with animated progress bars</li>
        <li>Latest blog posts preview</li>
        <li>Scroll-triggered AOS animations</li>
      </ul>
    </td>
    <td width="50%">
      <h3>📂 Projects Gallery</h3>
      <ul>
        <li>Filterable project listing</li>
        <li>Featured project ribbons</li>
        <li>Tech stack tags</li>
        <li>GitHub & live demo links</li>
        <li>Image upload with automatic resizing</li>
      </ul>
    </td>
  </tr>
  <tr>
    <td width="50%">
      <h3>📝 Blog Engine</h3>
      <ul>
        <li>Published post listing</li>
        <li>Multi-image support</li>
        <li>Tag-based categorization</li>
        <li>HTML content rendering</li>
        <li>External link integration</li>
      </ul>
    </td>
    <td width="50%">
      <h3>🎓 Curated Courses</h3>
      <ul>
        <li>YouTube course directory</li>
        <li>Auto-generated thumbnails</li>
        <li>Duration badges</li>
        <li>YouTube URL validation</li>
      </ul>
    </td>
  </tr>
  <tr>
    <td width="50%">
      <h3>📬 Smart Contact Form</h3>
      <ul>
        <li>Server + client-side validation</li>
        <li>IP address tracking</li>
        <li>SendGrid email notifications</li>
        <li>Graceful failure handling</li>
        <li>TempData feedback messages</li>
      </ul>
    </td>
    <td width="50%">
      <h3>🎨 Dark / Light Theme</h3>
      <ul>
        <li>CSS variable-based theming</li>
        <li>localStorage persistence</li>
        <li>Smooth toggle transitions</li>
      </ul>
    </td>
  </tr>
  <tr>
    <td width="50%">
      <h3>🛠️ Admin Modals</h3>
      <ul>
        <li>Inline CRUD via modal forms</li>
        <li>AJAX form submissions</li>
        <li>JSON API responses</li>
        <li>Image/file upload support</li>
      </ul>
    </td>
    <td width="50%">
      <h3>🔍 SEO Optimized</h3>
      <ul>
        <li>Open Graph & Twitter Card meta tags</li>
        <li>Auto-generated sitemap.xml</li>
        <li>robots.txt configuration</li>
        <li>Responsive design</li>
      </ul>
    </td>
  </tr>
</table>

---

## ⚙️ Tech Stack

<div align="center">

| Category | Technology |
|----------|-----------|
| **Framework** | ASP.NET Core MVC (.NET 10.0) |
| **Language** | C# — Nullable reference types, implicit usings |
| **ORM** | Entity Framework Core 10.0.9 |
| **Database** | SQL Server (LocalDB / SQLEXPRESS) |
| **Frontend** | Razor Views, Bootstrap 5.3.2, CSS3, Vanilla JS |
| **Email** | SendGrid API v9.29.3 |
| **Image Processing** | SixLabors.ImageSharp 3.1.12 |
| **Logging** | Serilog (Console + Rolling File) |
| **Validation** | FluentValidation.AspNetCore 11.3.1 |
| **Mapping** | AutoMapper 16.1.1 |
| **Identity** | ASP.NET Core Identity (ready for future auth) |
| **Animations** | AOS (Animate on Scroll) 2.3.1 |
| **Icons** | Font Awesome 6.5.1 |
| **Fonts** | Google Fonts (Inter, JetBrains Mono) |

</div>

---

## 🏁 Getting Started

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- SQL Server (LocalDB or Express)
- (Optional) [SendGrid API Key](https://sendgrid.com/) for email functionality

### Setup

```bash
# 1. Clone the repository
git clone https://github.com/yourusername/MyMvcProject.git
cd MyMvcProject

# 2. Update the connection string
#    Edit appsettings.json:
#    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=PortfolioDb;Trusted_Connection=True;TrustServerCertificate=True"

# 3. Restore dependencies
dotnet restore

# 4. Apply migrations and seed data
#    (Database auto-migrates on first run, or manually:)
dotnet ef database update

# 5. Run the application
dotnet run
```

The app will be available at `https://localhost:5001` (or the port shown in the console output). On first startup, the database is automatically created, migrated, and seeded with sample data.

### Configuration

| Setting | File | Description |
|---------|------|-------------|
| `ConnectionStrings:DefaultConnection` | `appsettings.json` | SQL Server connection string |
| `SendGrid:ApiKey` | `appsettings.json` | SendGrid API key for email |
| `SendGrid:SenderEmail` | `appsettings.json` | From address for notification emails |
| `SendGrid:SenderName` | `appsettings.json` | Display name for email sender |

---

## 📁 Project Structure

```
MyMvcProject/
├── Controllers/              # MVC controllers (7 controllers)
│   ├── HomeController.cs     #   Landing, privacy, error pages
│   ├── AboutController.cs    #   About page
│   ├── ProjectsController.cs #   Project CRUD
│   ├── SkillsController.cs   #   Skills management
│   ├── CoursesController.cs  #   Course CRUD
│   ├── BlogController.cs     #   Blog post management
│   └── ContactController.cs  #   Contact form handling
│
├── Models/
│   ├── Entities/             # EF Core entity classes (5 entities)
│   │   ├── Project.cs
│   │   ├── Skill.cs
│   │   ├── Course.cs
│   │   ├── BlogPost.cs
│   │   └── ContactMessage.cs
│   └── ViewModels/           # View-specific models & validators
│       ├── HomeViewModel.cs
│       ├── ProjectViewModel.cs
│       ├── SkillViewModel.cs
│       ├── CourseViewModel.cs
│       ├── BlogPostViewModel.cs
│       ├── ContactFormViewModel.cs
│       └── Custom validators
│
├── Data/
│   ├── ApplicationDbContext.cs   # EF Core DbContext
│   ├── DbSeeder.cs               # Seed data (14 skills, 1 project)
│   └── Configurations/           # Fluent API entity configs
│
├── Services/
│   ├── IEmailService.cs / EmailService.cs       # SendGrid integration
│   ├── IImageService.cs / ImageService.cs       # Image processing
│   └── IYouTubeService.cs / YouTubeService.cs   # YouTube URL handling
│
├── Views/
│   ├── Home/                    # Landing, Privacy views
│   ├── About/                   # About page
│   ├── Projects/                # Project listing
│   ├── Skills/                  # Skills showcase
│   ├── Courses/                 # Course directory
│   ├── Blog/                    # Blog listing
│   ├── Contact/                 # Contact form
│   └── Shared/                  # Layout, nav, footer, modals
│
├── wwwroot/
│   ├── css/                     # site.css, animations.css, theme
│   ├── js/                      # site.js, theme-toggle, admin-modals
│   └── images/                  # Uploaded images & profile pics
│
├── Program.cs                   # App entry point & DI setup
├── appsettings.json             # Configuration
└── MyMvcProject.csproj          # Project file
```

---

## 🔌 API Endpoints

### Public Pages

| Method | Route | Controller | Description |
|--------|-------|-----------|-------------|
| `GET` | `/` | Home | Landing page with hero, skills, projects, blog |
| `GET` | `/About` | About | About the developer |
| `GET` | `/Projects` | Projects | All projects listing |
| `GET` | `/Skills` | Skills | Skills grouped by category |
| `GET` | `/Courses` | Courses | Curated YouTube courses |
| `GET` | `/Blog` | Blog | Published blog posts |
| `GET` | `/Contact` | Contact | Contact form page |

### JSON API (Admin Operations)

| Method | Route | Description |
|--------|-------|-------------|
| `POST` | `/Projects/Create` | Create new project (multipart) |
| `GET` | `/Projects/GetProject/{id}` | Get project by ID |
| `POST` | `/Skills/Create` | Create new skill |
| `POST` | `/Courses/Create` | Create new course |
| `POST` | `/Blog/Create` | Create new blog post (multipart) |
| `POST` | `/Contact/Submit` | Submit contact form |

---

## 🧠 Architectural Highlights

- **Clean MVC Separation** — Models, Views, Controllers with dedicated ViewModels per page
- **Dependency Injection** — All services (Email, Image, YouTube) registered via DI
- **Service Layer Pattern** — Business logic abstracted behind interfaces
- **Fluent API Configurations** — EF Core entity configs kept separate from domain models
- **Async All the Way** — Fully async data access and service calls
- **POST-REDIRECT-GET** — Contact form and admin actions follow PRG pattern
- **Graceful Degradation** — Email failures don't block contact submissions
- **Auto-Migration** — Database migrates automatically on app startup
- **Structured Logging** — Serilog with daily rolling file + console output

---

## 🚦 Roadmap

- [x] Portfolio showcase with projects, skills, blog, courses
- [x] Contact form with SendGrid email integration
- [x] Dark/Light theme toggle
- [x] Responsive design with Bootstrap 5
- [x] SEO optimization (OG tags, sitemap, robots.txt)
- [ ] Admin authentication & authorization
- [ ] Blog post detail page with comments
- [ ] Project detail page with screenshots gallery
- [ ] Search functionality
- [ ] RSS feed for blog

---

## 📄 License

This project is **private/personal** — all rights reserved.

---

<div align="center">
  <sub>Built with ❤️ by <a href="https://faleelh.dev">Faleel H</a> — AI .NET Full Stack Developer</sub>
  <br/>
  <sub>⚡ Powered by ASP.NET Core MVC • EF Core • SQL Server • Bootstrap</sub>
</div>
