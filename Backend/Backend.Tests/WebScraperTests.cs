using backend.Entities;
using backend.Entities.Requests;
using FluentAssertions;

namespace Backend.Tests;

public class WebScraperTests
{
    [Fact]
    public async Task GetDataFromSite_ReturnsData()
    {
        var request = new ScraperRequest()
        {
            Url = "https://www.x-kom.pl/p/667824-pamiec-ram-ddr4-kingston-fury-16gb-2x8gb-3600mhz-cl17-beast-rgb.html",
            ProductId = 4,
            ShopId = 1,
        };
        var response = await Utils.GetData(request);
        response[0].Should().Be("279.00");
        response[1].Should().Be("5.9");
        response[2].Should().Be("346");
        response[3].Should().Be("-1");
    }
}