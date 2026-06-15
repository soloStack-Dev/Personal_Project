using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.ViewModels
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file && file.Length > _maxFileSize)
            {
                return new ValidationResult($"File size cannot exceed {_maxFileSize / 1024 / 1024}MB.");
            }
            else if (value is IEnumerable<IFormFile> files)
            {
                foreach (var f in files)
                {
                    if (f.Length > _maxFileSize)
                    {
                        return new ValidationResult($"File size cannot exceed {_maxFileSize / 1024 / 1024}MB.");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
