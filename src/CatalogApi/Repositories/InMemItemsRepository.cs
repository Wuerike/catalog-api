using CatalogApi.Models; 

namespace CatalogApi.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Item 1", Price = 1, CreatedAt = DateTime.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Item 2", Price = 2, CreatedAt = DateTime.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Item 3", Price = 3, CreatedAt = DateTime.UtcNow }
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }

        public async Task<Item?> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.Where(item => item.Id == id).SingleOrDefault());
        }

        public async Task CreateItemAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(actualItem => actualItem.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(actualItem => actualItem.Id == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }

    }
}