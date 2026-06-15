namespace Portfolio.Services
{
    public interface IYouTubeService
    {
        string? ExtractVideoId(string youtubeUrl);
        string GetThumbnailUrl(string? videoId, string quality = "maxresdefault");
        bool IsValidYouTubeUrl(string url);
    }
}
