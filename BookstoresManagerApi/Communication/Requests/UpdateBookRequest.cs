using System.ComponentModel.DataAnnotations;
using BookstoresManagerApi.Validators;

namespace BookstoresManagerApi.Communication.Requests
{
    public class UpdateBookRequest
    {
        [Required]
        [StringLength(120, MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(120, MinimumLength = 2)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [AllowedGenres]
        public string Genre { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; } = 0.0m;

        [Range(0, int.MaxValue)]
        public int Stock { get; set; } = 0;
    }
}