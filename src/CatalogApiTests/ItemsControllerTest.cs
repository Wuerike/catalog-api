using System;
using System.Threading.Tasks;
using CatalogApi.Controllers;
using CatalogApi.Dtos;
using CatalogApi.Models;
using CatalogApi.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CatalogApiTests;

public class ItemsControllerTests
{
    private readonly Mock<IItemsRepository> repositoryStub = new();
    private readonly Random Rand = new();

    private Item CreateRandomItem()
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString(),
            Price = Rand.Next(1000),
            CreatedAt = DateTime.UtcNow
        };
    }

    [Fact]
    public async Task GetItemAsync_WithNullItem_ReturnsNotFound()
    {
        repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>())).ReturnsAsync((Item)null);
        var controller = new ItemsController(repositoryStub.Object);

        var result = await controller.GetItemAsync(Guid.NewGuid());
        result.Result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task GetItemAsync_WithExistingItem_ReturnsExpectedItem()
    {
        var expectedItem = CreateRandomItem();

        repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>())).ReturnsAsync((expectedItem));
        var controller = new ItemsController(repositoryStub.Object);

        var result = await controller.GetItemAsync(Guid.NewGuid());
        result.Value.Should().BeEquivalentTo(
            expectedItem,
            options => options.ComparingByMembers<Item>()
        );
    }

    [Fact]
    public async Task GetItemsAsync_WithExistingItem_ReturnsAllItems()
    {
        var expectedItems = new[]{CreateRandomItem(), CreateRandomItem(), CreateRandomItem()};
        
        repositoryStub.Setup(repo => repo.GetItemsAsync()).ReturnsAsync((expectedItems));
        var controller = new ItemsController(repositoryStub.Object);

        var result = await controller.GetItemsAsync();
        result.Value.Should().BeEquivalentTo(
            expectedItems,
            options => options.ComparingByMembers<Item>()
        );
    }

    [Fact]
    public async Task CreateItemAsync_ReceivingItem_ReturnsCreatedItem()
    {
        var itemToCreate = new ItemRequestDto(){
            Name = Guid.NewGuid().ToString(),
            Price = Rand.Next(1000),
        };

        var controller = new ItemsController(repositoryStub.Object);

        var result = await controller.CreateItemAsync(itemToCreate);
        var createdItem = (result.Result as CreatedAtActionResult).Value as ItemResponseDto;

        createdItem.Should().BeEquivalentTo(
            itemToCreate,
            options => options.ComparingByMembers<ItemResponseDto>().ExcludingMissingMembers()
        );
        createdItem.Id.Should().NotBeEmpty();
        createdItem.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, System.TimeSpan.FromSeconds(1));
    }
}