using System.Net;
using backend.Entities.Models;
using FluentAssertions;

namespace Backend.Tests;

public class OrdersControllerTests : IntegrationTest
{
    private readonly string Url = "https://localhost:5001/api/Orders";
    
    [Fact]
    public async Task GetAll_ReturnsAllOrders()
    {
        var response = await TestClient.GetAsync(Url);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var orders = await response.Content.ReadAsAsync<List<Order>>();

        orders[0].OrderId.Should().Be(1);
        orders[0].OrderNumber.Should().Be(53);
        orders[0].ProductId.Should().Be(4);
        orders[0].ShopId.Should().Be(2);
    }
    
    [Fact]
    public async Task GetByProductId_ReturnsOrders()
    {
        var response = await TestClient.GetAsync(Url+"/byProductId?productId=5");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var orders = await response.Content.ReadAsAsync<List<Order>>();

        orders[0].OrderId.Should().Be(2);
        orders[0].OrderNumber.Should().Be(1);
        orders[0].ProductId.Should().Be(5);
        orders[0].ShopId.Should().Be(2);
    }
}