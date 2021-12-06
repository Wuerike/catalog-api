using System;
using System.Threading.Tasks;
using CatalogApi.Controllers;
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

        var result = await  controller.GetItemAsync(Guid.NewGuid());

        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetItemAsync_WithExistingItem_ReturnsExpectedItem()
    {
        var expectedItem = CreateRandomItem();
        var expectedDto = expectedItem.AsDto();
        repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>())).ReturnsAsync((expectedItem));
        var controller = new ItemsController(repositoryStub.Object);

        var result = await  controller.GetItemAsync(Guid.NewGuid());

        result.Value.Should().BeEquivalentTo(expectedDto);
    }
}