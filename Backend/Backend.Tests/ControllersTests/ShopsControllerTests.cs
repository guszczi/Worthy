using System.Net;
using backend.Entities.Models;
using FluentAssertions;

namespace Backend.Tests;

public class ShopsControllerTests : IntegrationTest
{
    private readonly string Url = "https://localhost:5001/api/Shops";
    
    [Fact]
    public async Task GetAll_ReturnsAllShops()
    {
        var response = await TestClient.GetAsync(Url);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var shops = await response.Content.ReadAsAsync<List<Shop>>();

        shops[0].ShopId.Should().Be(1);
        shops[0].ShopName.Should().Be("X-kom");
    }
}