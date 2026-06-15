using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.ViewModels
{
    public class ContactFormViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [Display(Name = "Your Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [StringLength(200, ErrorMessage = "Email cannot exceed 200 characters")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Your Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Message is required")]
        [StringLength(4000, ErrorMessage = "Message cannot exceed 4000 characters")]
        [MinLength(10, ErrorMessage = "Message must be at least 10 characters")]
        [Display(Name = "Your Message")]
        public string Message { get; set; } = string.Empty;
    }
}
