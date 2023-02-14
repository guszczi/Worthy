using System.Net;
using backend.Entities.Models;
using FluentAssertions;

namespace Backend.Tests;

public class LinksControllerTests : IntegrationTest
{
    private readonly string Url = "https://localhost:5001/api/Links";
    
    [Fact]
    public async Task GetAll_ReturnsAllLinks()
    {
        var response = await TestClient.GetAsync(Url);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var links = await response.Content.ReadAsAsync<List<Link>>();

        links[0].LinkId.Should().Be(2);
        links[0].LinkUrl.Should().Be("https://www.x-kom.pl/p/513002-konsola-nintendo-nintendo-switch-joy-con-czerwony-niebieski.html");
        links[0].ProductId.Should().Be(4);
        links[0].ShopId.Should().Be(1);
    }
    
    [Fact]
    public async Task GetByProductId_ReturnsLinks()
    {
        var response = await TestClient.GetAsync(Url+"/byProductId?productId=4");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var links = await response.Content.ReadAsAsync<List<Link>>();

        links[1].LinkId.Should().Be(3);
        links[1].LinkUrl.Should().Be("https://www.morele.net/nintendo-switch-v2-red-blue-1410037/");
        links[1].ProductId.Should().Be(4);
        links[1].ShopId.Should().Be(2);
    }
}