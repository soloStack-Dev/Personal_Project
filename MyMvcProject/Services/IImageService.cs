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
