using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.ViewModels
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!_extensions.Contains(extension))
                {
                    return new ValidationResult($"Only {string.Join(", ", _extensions)} files are allowed.");
                }
            }
            else if (value is IEnumerable<IFormFile> files)
            {
                foreach (var f in files)
                {
                    var extension = Path.GetExtension(f.FileName).ToLowerInvariant();
                    if (!_extensions.Contains(extension))
                    {
                        return new ValidationResult($"Only {string.Join(", ", _extensions)} files are allowed.");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
