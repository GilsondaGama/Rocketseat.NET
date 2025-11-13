using System.ComponentModel.DataAnnotations;

namespace BookstoresManagerApi.Validators
{
    public class AllowedGenresAttribute : ValidationAttribute
    {
        private static readonly string[] Allowed = new[]
        {
            "ficcao", "ficção", "romance", "misterio", "mistério", "fantasia", "nao-ficcao", "não-ficção", "outro"
        };

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string s || string.IsNullOrWhiteSpace(s))
                return new ValidationResult("Genre is required.");

            var normalized = s.Trim().ToLowerInvariant();
            if (Allowed.Contains(normalized))
                return ValidationResult.Success;

            return new ValidationResult($"O gênero '{s}' não é permitido. Valores permitidos: {string.Join(", ", Allowed)}.");
        }
    }
}