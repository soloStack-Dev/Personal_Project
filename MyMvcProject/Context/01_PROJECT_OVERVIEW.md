# Personal Portfolio - ASP.NET Core MVC

## Project Overview
Build a personal portfolio website for **Faleel H** (AI .NET Full Stack Developer) using ASP.NET Core MVC with Razor views, Bootstrap 5, and MS SQL Server backend.

## Core Requirements
1. **Persistent Data Storage**: All user-created content (Projects, Skills, Courses, Blog Posts, Contact Messages) must persist in MS SQL Server via Entity Framework Core
2. **CRUD Operations**: Admin can add new Projects, Skills, Courses, and Blog Posts through modal forms
3. **Email Notifications**: Contact form submissions send email to faleelmr4@gmail.com via SendGrid
4. **Theme Toggle**: Light/Dark mode with CSS variables and localStorage persistence
5. **YouTube Thumbnail Auto-Generation**: Course page auto-fetches thumbnails from YouTube URLs
6. **Image Upload Support**: Multiple image upload for projects and blog posts

## Technology Stack
- **Framework**: ASP.NET Core MVC 8.0
- **Language**: C# 12.0
- **Database**: MS SQL Server + Entity Framework Core 8.0
- **Frontend**: Razor Views + HTML5 + Bootstrap 5.3 + CSS3 + Vanilla JavaScript
- **Email Service**: SendGrid API
- **Image Processing**: SixLabors.ImageSharp
- **Validation**: FluentValidation
- **Object Mapping**: AutoMapper
- **Logging**: Serilog

## Project Structure
```
Portfolio/
├── Controllers/
│   ├── HomeController.cs
│   ├── AboutController.cs
│   ├── ProjectsController.cs
│   ├── SkillsController.cs
│   ├── CoursesController.cs
│   ├── BlogController.cs
│   ├── ContactController.cs
│   └── AdminController.cs
├── Models/
│   ├── Entities/
│   │   ├── Project.cs
│   │   ├── Skill.cs
│   │   ├── Course.cs
│   │   ├── BlogPost.cs
│   │   └── ContactMessage.cs
│   ├── ViewModels/
│   │   ├── ProjectViewModel.cs
│   │   ├── SkillViewModel.cs
│   │   ├── CourseViewModel.cs
│   │   ├── BlogPostViewModel.cs
│   │   ├── ContactFormViewModel.cs
│   │   └── HomeViewModel.cs
│   └── Enums/
│       └── SkillCategory.cs
├── Data/
│   ├── ApplicationDbContext.cs
│   └── Configurations/
│       ├── ProjectConfiguration.cs
│       ├── SkillConfiguration.cs
│       ├── CourseConfiguration.cs
│       ├── BlogPostConfiguration.cs
│       └── ContactMessageConfiguration.cs
├── Services/
│   ├── EmailService.cs
│   ├── ImageService.cs
│   └── YouTubeService.cs
├── Migrations/ (EF Core generated)
├── Views/
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   ├── _Navigation.cshtml
│   │   ├── _Footer.cshtml
│   │   ├── _AdminModals.cshtml
│   │   └── _ValidationScriptsPartial.cshtml
│   ├── Home/
│   │   └── Index.cshtml
│   ├── About/
│   │   └── Index.cshtml
│   ├── Projects/
│   │   └── Index.cshtml
│   ├── Skills/
│   │   └── Index.cshtml
│   ├── Courses/
│   │   └── Index.cshtml
│   ├── Blog/
│   │   └── Index.cshtml
│   └── Contact/
│       └── Index.cshtml
├── wwwroot/
│   ├── css/
│   │   ├── site.css (dark theme default)
│   │   ├── light-theme.css
│   │   └── animations.css
│   ├── js/
│   │   ├── site.js
│   │   ├── theme-toggle.js
│   │   ├── admin-modals.js
│   │   └── form-validation.js
│   ├── images/
│   │   ├── uploads/ (user uploaded images)
│   │   ├── projects/
│   │   ├── blog/
│   │   └── hero/
│   └── lib/
│       └── bootstrap/ (if local, else use CDN)
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
└── Portfolio.csproj
```

## NuGet Packages Required
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.0" />
<PackageReference Include="SendGrid" Version="9.29.0" />
<PackageReference Include="SixLabors.ImageSharp" Version="3.1.0" />
<PackageReference Include="FluentValidation.AspNetCore" Version="11.3.0" />
<PackageReference Include="AutoMapper" Version="13.0.0" />
<PackageReference Include="Serilog.AspNetCore" Version="8.0.0" />
<PackageReference Include="Serilog.Sinks.File" Version="5.0.0" />
```

## Database Connection String (appsettings.json)
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\mssqllocaldb;Database=PortfolioDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  },
  "SendGrid": {
    "ApiKey": "your-sendgrid-api-key-here",
    "FromEmail": "portfolio@faleelh.dev",
    "FromName": "Faleel H Portfolio",
    "ToEmail": "faleelmr4@gmail.com"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

## Color System (CSS Variables)
```css
:root {
  /* Dark Theme (Default) */
  --bg-primary: #0f172a;
  --bg-secondary: #1e1b4b;
  --bg-tertiary: #312e81;
  --card-bg: rgba(30, 41, 59, 0.6);
  --accent-primary: #0ea5e9;
  --accent-secondary: #8b5cf6;
  --accent-glow: #7c3aed;
  --text-primary: #f8fafc;
  --text-secondary: #94a3b8;
  --border-color: rgba(148, 163, 184, 0.1);
  --success: #10b981;
  --hover-accent: #38bdf8;
}

[data-theme="light"] {
  --bg-primary: #f8fafc;
  --bg-secondary: #e2e8f0;
  --bg-tertiary: #cbd5e1;
  --card-bg: #ffffff;
  --accent-primary: #0284c7;
  --accent-secondary: #7c3aed;
  --accent-glow: #6d28d9;
  --text-primary: #0f172a;
  --text-secondary: #475569;
  --border-color: rgba(148, 163, 184, 0.2);
  --success: #059669;
  --hover-accent: #0369a1;
}
```

## Typography
- Headings: Inter, Poppins (Google Fonts)
- Body: Inter, 400 weight
- Code/Tags: JetBrains Mono, Fira Code
- Hero Name: 64-80px, weight 800
- Section Titles: 36-48px, weight 700
- Card Titles: 20-24px, weight 600
- Body Text: 16-18px, line-height 1.7

## Global Animations
- Page load: staggered fade-in from bottom, 0.6s ease-out
- Scroll reveal: elements fade-in when entering viewport (use AOS library or IntersectionObserver)
- Card hover: translateY(-4px), shadow intensify, 0.3s ease
- Button hover: scale(1.02), gradient shift
- Link hover: underline grows from left
- Theme transition: smooth color transition 0.5s ease across all elements
- Skill bars: animate width from 0 to value on scroll into view
- Form inputs: focus border glow #0ea5e9

## Responsive Breakpoints
- Mobile: < 640px (single column, hamburger menu)
- Tablet: 640px - 1024px (2 columns, condensed nav)
- Desktop: > 1024px (full layout)

## SEO Requirements
- Meta tags for each page
- Open Graph tags for social sharing
- Structured data (JSON-LD) for Person schema
- Sitemap.xml generation
- robots.txt

## Security Requirements
- CSRF tokens on all forms
- Input validation (server-side + client-side)
- File upload validation (image types only: jpg, png, gif, webp)
- File size limit: 5MB per image
- Anti-forgery tokens on POST actions
- XSS prevention (Razor auto-encodes by default)

## Performance Requirements
- Lazy loading for images
- Minified CSS/JS in production
- Database query optimization (Include/Eager loading where needed)
- Image compression on upload (max width 1920px, quality 80%)
- CDN for static assets (optional)

## Implementation Order
1. Project setup + NuGet packages + Database context + Entity models
2. _Layout.cshtml + Navigation + Footer + Theme toggle
3. Home page (Hero + Skills + Projects + Blog sections)
4. About page
5. Contact page + Email service
6. Admin modals (Add Project/Skill/Course/Blog)
7. Courses page + YouTube thumbnail service
8. Image upload service + processing
9. Validation + Error handling + Logging
10. Polish: animations, responsive testing, SEO, performance
