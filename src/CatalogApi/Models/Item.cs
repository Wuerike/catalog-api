namespace CatalogApi.Models
{

    public record Item{

        public Guid Id {get; init;}
        public string? Name { get; init; }
        public decimal Price { get; init; }
        public DateTime CreatedAt { get; init; }

    }
}