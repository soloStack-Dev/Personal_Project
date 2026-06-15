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
