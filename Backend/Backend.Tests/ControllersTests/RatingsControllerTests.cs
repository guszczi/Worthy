using System.Net;
using backend.Entities.Models;
using FluentAssertions;

namespace Backend.Tests;

public class RatingsControllerTests : IntegrationTest
{
    private readonly string Url = "https://localhost:5001/api/Ratings";
    
    [Fact]
    public async Task GetAll_ReturnsAllOrders()
    {
        var response = await TestClient.GetAsync(Url);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var ratings = await response.Content.ReadAsAsync<List<Rating>>();

        ratings[0].RatingId.Should().Be(4);
        ratings[0].RatingGrade.Should().Be(5.7);
        ratings[0].RatingNumber.Should().Be(113);
        ratings[0].ProductId.Should().Be(4);
        ratings[0].ShopId.Should().Be(1);
    }
    
    [Fact]
    public async Task GetByProductId_ReturnsOrders()
    {
        var response = await TestClient.GetAsync(Url+"/byProductId?productId=5");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var ratings = await response.Content.ReadAsAsync<List<Rating>>();

        ratings[0].RatingId.Should().Be(7);
        ratings[0].RatingGrade.Should().Be(4.6);
        ratings[0].RatingNumber.Should().Be(7);
        ratings[0].ProductId.Should().Be(5);
        ratings[0].ShopId.Should().Be(1);
    }
}