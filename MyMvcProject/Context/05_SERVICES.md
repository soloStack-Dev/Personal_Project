# Services (Services/)

## IEmailService.cs (Interface)
```csharp
namespace Portfolio.Services
{
    public interface IEmailService
    {
        Task<bool> SendContactNotificationAsync(string fromName, string fromEmail, string message);
        Task<bool> SendEmailAsync(string toEmail, string subject, string htmlContent, string? plainTextContent = null);
    }
}
```

## EmailService.cs (Implementation)
```csharp
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portfolio.Services
{
    public class EmailService : IEmailService
    {
        private readonly ISendGridClient _sendGridClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
            var apiKey = configuration["SendGrid:ApiKey"] ?? throw new InvalidOperationException("SendGrid API Key not configured");
            _sendGridClient = new SendGridClient(apiKey);
        }

        public async Task<bool> SendContactNotificationAsync(string fromName, string fromEmail, string message)
        {
            try
            {
                var toEmail = _configuration["SendGrid:ToEmail"] ?? "faleelmr4@gmail.com";
                var fromAddress = new EmailAddress(
                    _configuration["SendGrid:FromEmail"] ?? "portfolio@faleelh.dev",
                    _configuration["SendGrid:FromName"] ?? "Faleel H Portfolio");

                var subject = $"New Contact Form Message from {fromName}";

                var htmlContent = $@"
                    <div style='font-family: Inter, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #e2e8f0; border-radius: 12px;'>
                        <h2 style='color: #0f172a; border-bottom: 2px solid #0ea5e9; padding-bottom: 10px;'>New Contact Message</h2>
                        <div style='margin: 20px 0;'>
                            <p><strong style='color: #0ea5e9;'>From:</strong> {fromName}</p>
                            <p><strong style='color: #0ea5e9;'>Email:</strong> <a href='mailto:{fromEmail}'>{fromEmail}</a></p>
                            <p><strong style='color: #0ea5e9;'>Date:</strong> {DateTime.Now:MMMM dd, yyyy HH:mm}</p>
                        </div>
                        <div style='background: #f8fafc; padding: 15px; border-radius: 8px; border-left: 4px solid #0ea5e9;'>
                            <p style='margin: 0; white-space: pre-wrap;'>{System.Net.WebUtility.HtmlEncode(message)}</p>
                        </div>
                        <p style='margin-top: 20px; font-size: 12px; color: #94a3b8;'>Sent from your Portfolio Contact Form</p>
                    </div>";

                var plainTextContent = $@"New Contact Message
From: {fromName}
Email: {fromEmail}
Date: {DateTime.Now:MMMM dd, yyyy HH:mm}

Message:
{message}";

                var msg = new SendGridMessage()
                {
                    From = fromAddress,
                    Subject = subject,
                    PlainTextContent = plainTextContent,
                    HtmlContent = htmlContent
                };
                msg.AddTo(new EmailAddress(toEmail));

                var response = await _sendGridClient.SendEmailAsync(msg);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Contact notification email sent successfully to {ToEmail}", toEmail);
                    return true;
                }
                else
                {
                    var responseBody = await response.Body.ReadAsStringAsync();
                    _logger.LogError("Failed to send email. Status: {StatusCode}, Body: {Body}", response.StatusCode, responseBody);
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while sending contact notification email");
                return false;
            }
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string htmlContent, string? plainTextContent = null)
        {
            try
            {
                var fromAddress = new EmailAddress(
                    _configuration["SendGrid:FromEmail"] ?? "portfolio@faleelh.dev",
                    _configuration["SendGrid:FromName"] ?? "Faleel H Portfolio");

                var msg = new SendGridMessage()
                {
                    From = fromAddress,
                    Subject = subject,
                    PlainTextContent = plainTextContent ?? "",
                    HtmlContent = htmlContent
                };
                msg.AddTo(new EmailAddress(toEmail));

                var response = await _sendGridClient.SendEmailAsync(msg);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while sending email to {ToEmail}", toEmail);
                return false;
            }
        }
    }
}
```

## IImageService.cs (Interface)
```csharp
namespace Portfolio.Services
{
    public interface IImageService
    {
        Task<string?> SaveImageAsync(IFormFile imageFile, string folder);
        Task<List<string>> SaveImagesAsync(List<IFormFile> imageFiles, string folder);
        Task<bool> DeleteImageAsync(string? imagePath);
        string GetImageUrl(string? imagePath);
    }
}
```

## ImageService.cs (Implementation)
```csharp
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace Portfolio.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ImageService> _logger;
        private const int MaxImageWidth = 1920;
        private const int MaxImageHeight = 1080;
        private const int JpegQuality = 80;

        public ImageService(IWebHostEnvironment environment, ILogger<ImageService> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public async Task<string?> SaveImageAsync(IFormFile imageFile, string folder)
        {
            if (imageFile == null || imageFile.Length == 0)
                return null;

            try
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "images", folder);
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(imageFile.FileName)}";
                var filePath = Path.Combine(uploadsFolder, fileName);
                var relativePath = $"/images/{folder}/{fileName}";

                using (var image = await Image.LoadAsync(imageFile.OpenReadStream()))
                {
                    // Resize if larger than max dimensions
                    if (image.Width > MaxImageWidth || image.Height > MaxImageHeight)
                    {
                        image.Mutate(x => x.Resize(new ResizeOptions
                        {
                            Mode = ResizeMode.Max,
                            Size = new Size(MaxImageWidth, MaxImageHeight)
                        }));
                    }

                    // Save as JPEG with quality setting
                    var encoder = new JpegEncoder { Quality = JpegQuality };
                    await image.SaveAsync(filePath, encoder);
                }

                _logger.LogInformation("Image saved: {FilePath}", relativePath);
                return relativePath;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving image {FileName}", imageFile.FileName);
                return null;
            }
        }

        public async Task<List<string>> SaveImagesAsync(List<IFormFile> imageFiles, string folder)
        {
            var savedPaths = new List<string>();

            foreach (var file in imageFiles)
            {
                var path = await SaveImageAsync(file, folder);
                if (path != null)
                    savedPaths.Add(path);
            }

            return savedPaths;
        }

        public Task<bool> DeleteImageAsync(string? imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return Task.FromResult(false);

            try
            {
                var fullPath = Path.Combine(_environment.WebRootPath, imagePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    _logger.LogInformation("Image deleted: {ImagePath}", imagePath);
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting image {ImagePath}", imagePath);
                return Task.FromResult(false);
            }
        }

        public string GetImageUrl(string? imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return "/images/placeholder.jpg";
            return imagePath;
        }
    }
}
```

## IYouTubeService.cs (Interface)
```csharp
namespace Portfolio.Services
{
    public interface IYouTubeService
    {
        string? ExtractVideoId(string youtubeUrl);
        string GetThumbnailUrl(string? videoId, string quality = "maxresdefault");
        bool IsValidYouTubeUrl(string url);
    }
}
```

## YouTubeService.cs (Implementation)
```csharp
using System.Text.RegularExpressions;

namespace Portfolio.Services
{
    public class YouTubeService : IYouTubeService
    {
        private static readonly Regex[] YouTubeRegexPatterns = new[]
        {
            new Regex(@"(?:youtube\.com/watch\?v=|youtu\.be/|youtube\.com/embed/|youtube\.com/v/|youtube\.com/shorts/)([a-zA-Z0-9_-]{11})", RegexOptions.Compiled),
            new Regex(@"youtube\.com/watch\?.*v=([a-zA-Z0-9_-]{11})", RegexOptions.Compiled)
        };

        public string? ExtractVideoId(string youtubeUrl)
        {
            if (string.IsNullOrWhiteSpace(youtubeUrl))
                return null;

            foreach (var pattern in YouTubeRegexPatterns)
            {
                var match = pattern.Match(youtubeUrl);
                if (match.Success && match.Groups.Count > 1)
                {
                    return match.Groups[1].Value;
                }
            }

            return null;
        }

        public string GetThumbnailUrl(string? videoId, string quality = "maxresdefault")
        {
            if (string.IsNullOrEmpty(videoId))
                return "/images/youtube-placeholder.jpg";

            // Available qualities: maxresdefault, sddefault, hqdefault, mqdefault, default
            var validQualities = new[] { "maxresdefault", "sddefault", "hqdefault", "mqdefault", "default" };
            var selectedQuality = validQualities.Contains(quality) ? quality : "maxresdefault";

            return $"https://img.youtube.com/vi/{videoId}/{selectedQuality}.jpg";
        }

        public bool IsValidYouTubeUrl(string url)
        {
            return !string.IsNullOrWhiteSpace(url) && ExtractVideoId(url) != null;
        }
    }
}
```
