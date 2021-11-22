using Catalog_api.Dtos;
using Catalog_api.Models;
using Catalog_api.Repositories;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog_api.Controllers
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
            var actualItem = await repository.GetItemAsync(id);

            if (actualItem is null)
            {
                return NotFound();
            }

            Item updatedItem = actualItem with
            {
                Name = request.Name,
                Price = request.Price
            };

            await repository.UpdateItemAsync(updatedItem);
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