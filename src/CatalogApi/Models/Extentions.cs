using CatalogApi.Dtos;

namespace CatalogApi.Models
{

    public static class Extentions
    {
        
        public static ItemResponseDto AsDto(this Item item)
        {
            return new ItemResponseDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedAt = item.CreatedAt
            };
        }
    }
}