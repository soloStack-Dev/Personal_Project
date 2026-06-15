using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models.Entities;
using Portfolio.Models.ViewModels;
using Portfolio.Services;

namespace Portfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(ApplicationDbContext context, IEmailService emailService, ILogger<ContactController> logger)
        {
            _context = context;
            _emailService = emailService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ContactFormViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            try
            {
                var contactMessage = new ContactMessage
                {
                    Name = model.Name,
                    Email = model.Email,
                    Message = model.Message,
                    SentDate = DateTime.UtcNow,
                    IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString()
                };

                _context.ContactMessages.Add(contactMessage);
                await _context.SaveChangesAsync();

                var emailSent = await _emailService.SendContactNotificationAsync(
                    model.Name,
                    model.Email,
                    model.Message
                );

                if (emailSent)
                {
                    TempData["SuccessMessage"] = "Thank you! Your message has been sent successfully. I'll get back to you soon.";
                    _logger.LogInformation("Contact form submitted and email sent from {Email}", model.Email);
                }
                else
                {
                    TempData["WarningMessage"] = "Your message was saved, but there was an issue sending the notification email. I'll still receive your message.";
                    _logger.LogWarning("Contact form saved but email failed from {Email}", model.Email);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing contact form from {Email}", model.Email);
                ModelState.AddModelError("", "An error occurred while sending your message. Please try again later.");
                return View("Index", model);
            }
        }
    }
}
