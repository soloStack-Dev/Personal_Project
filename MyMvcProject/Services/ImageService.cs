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
                    if (image.Width > MaxImageWidth || image.Height > MaxImageHeight)
                    {
                        image.Mutate(x => x.Resize(new ResizeOptions
                        {
                            Mode = ResizeMode.Max,
                            Size = new Size(MaxImageWidth, MaxImageHeight)
                        }));
                    }

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
