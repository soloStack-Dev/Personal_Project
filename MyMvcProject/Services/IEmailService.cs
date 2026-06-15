namespace Portfolio.Services
{
    public interface IEmailService
    {
        Task<bool> SendContactNotificationAsync(string fromName, string fromEmail, string message);
        Task<bool> SendEmailAsync(string toEmail, string subject, string htmlContent, string? plainTextContent = null);
    }
}
