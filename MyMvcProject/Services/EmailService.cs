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
