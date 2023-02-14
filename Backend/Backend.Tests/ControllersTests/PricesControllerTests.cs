using System.Net;
using backend.Entities.Models;
using FluentAssertions;

namespace Backend.Tests;

public class PricesControllerTests : IntegrationTest
{
    private readonly string Url = "https://localhost:5001/api/Prices";
    
    [Fact]
    public async Task GetAll_ReturnsAllPrices()
    {
        var response = await TestClient.GetAsync(Url);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var prices = await response.Content.ReadAsAsync<List<Price>>();

        prices[0].PriceId.Should().Be(4);
        prices[0].PriceValue.Should().Be(1399);
        prices[0].ProductId.Should().Be(4);
        prices[0].ShopId.Should().Be(1);
    }

    [Fact]
    public async Task GetByProductId_ReturnsPrices()
    {
        var response = await TestClient.GetAsync(Url+"/byProductId?id=6");
        
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var prices = await response.Content.ReadAsAsync<List<Price>>();

        prices[0].PriceId.Should().Be(11);
        prices[0].PriceValue.Should().Be(389);
        prices[0].ProductId.Should().Be(6);
        prices[0].ShopId.Should().Be(1);
    }
    
    [Fact]
    public async Task GetByDate_ReturnsPrices()
    {
        var response = await TestClient.GetAsync(Url+"/byDate?date=2023-02-11");
        
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var prices = await response.Content.ReadAsAsync<List<Price>>();

        prices[1].PriceId.Should().Be(5);
        prices[1].PriceValue.Should().Be(1388.39);
        prices[1].ProductId.Should().Be(4);
        prices[1].ShopId.Should().Be(2);
    }
    
    [Fact]
    public async Task GetHistoricalLowByProductId_ReturnsPrice()
    {
        var response = await TestClient.GetAsync(Url+"/historicalByProductId?id=7");
        
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var price = await response.Content.ReadAsAsync<Price>();

        price.PriceId.Should().Be(16);
        price.PriceValue.Should().Be(509);
        price.ProductId.Should().Be(7);
        price.ShopId.Should().Be(2);
    }
    
    [Fact]
    public async Task GetDailyPricesByProductId_ReturnsPrices()
    {
        var response = await TestClient.GetAsync(Url+"/dailyPriceByProductId?id=6");
        
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var price = await response.Content.ReadAsAsync<List<Price>>();
        
        price[0].PriceValue.Should().Be(389);
    }
}