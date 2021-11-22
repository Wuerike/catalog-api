using System.ComponentModel.DataAnnotations;

namespace Catalog_api.Dtos
{

    public record ItemRequestDto{
        [Required]
        public string? Name { get; init; }
        [Required]
        [Range(0d, (double)decimal.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Price { get; init; }
    }
}