using System.ComponentModel.DataAnnotations;

namespace CatalogApi.Dtos
{
    public record ItemRequestDto(
        [Required]
        string? Name,

        [Required]
        [Range(0d, (double)decimal.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        decimal Price
    );

    public record ItemResponseDto(
        Guid Id,

        string? Name,

        decimal Price,
        
        DateTime CreatedAt
    );
}