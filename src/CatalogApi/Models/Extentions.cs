using CatalogApi.Dtos;

namespace CatalogApi.Models
{

    public static class Extentions
    {
        
        public static ItemResponseDto AsDto(this Item item)
        {
            return new ItemResponseDto(item.Id, item.Name, item.Price, item.CreatedAt);
        }
    }
}