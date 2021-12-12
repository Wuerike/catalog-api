using CatalogApi.Dtos;
using CatalogApi.Models;
using CatalogApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet] // GET /items
        public async Task<ActionResult<IEnumerable<ItemResponseDto>>> GetItemsAsync()
        {
            var items = (await repository.GetItemsAsync()).Select(item => item.AsDto());

            if (!items.Any())
            {
                return NotFound();
            }

            return items.ToList();
        }

        [HttpGet("{id}")] // GET /items/{id}
        public async Task<ActionResult<ItemResponseDto>> GetItemAsync(Guid id)
        {
            var item = await repository.GetItemAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost] // POST /items
        public async Task<ActionResult<ItemResponseDto>> CreateItemAsync(ItemRequestDto request)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                CreatedAt = DateTime.UtcNow
            };

            await repository.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItemAsync), new{id = item.Id}, item.AsDto());
        }

        [HttpPut("{id}")] // PUT /items/{id}
        public async Task<ActionResult> UpdateItemAsync(Guid id, ItemRequestDto request)
        {
            var itemToUpdate = await repository.GetItemAsync(id);

            if (itemToUpdate is null)
            {
                return NotFound();
            }

            itemToUpdate.Name = request.Name;
            itemToUpdate.Price = request.Price;

            await repository.UpdateItemAsync(itemToUpdate);
            return NoContent();
        }

        [HttpDelete("{id}")] // PUT /items/{id}
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var actualItem = await repository.GetItemAsync(id);

            if (actualItem is null)
            {
                return NotFound();
            }

            await repository.DeleteItemAsync(id);
            return NoContent();
        }

    }
}