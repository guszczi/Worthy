using System.Net;
using backend.Entities.Models;
using FluentAssertions;

namespace Backend.Tests;

public class ProductsControllerTests : IntegrationTest
{
    private readonly string Url = "https://localhost:5001/api/Products";
    
    [Fact]
    public async Task GetAll_ReturnsAllProducts()
    {
        var response = await TestClient.GetAsync(Url);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var products = await response.Content.ReadAsAsync<List<Product>>();

        products[0].ProductId.Should().Be(4);
        products[0].ProductName.Should().Be("Nintendo Switch Joy-Con - Czerwony / Niebieski");
        products[0].ProductDescription.Should().Be("Konsola do gier Nintendo Switch 32GB z 4 GB RAM z napędem optycznym " +
                                                   "Brak. Konsola zawiera złącza: USB, HDMI, Czytnik kart pamięci. Rodzaj konsoli: Przenośne. Wersja: Podstawowa");
        products[0].ProductImageUrl.Should().Be("https://cdn.x-kom.pl/i/setup/images/prod/big/product-new-big,,2019/8/pr_2019_8_28_14_59_52_23_01.jpg");
    }

    [Fact]
    public async Task GetProductByProductId_ReturnsProduct()
    {
        var response = await TestClient.GetAsync(Url+"/6");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var product = await response.Content.ReadAsAsync<Product>();

        product.ProductId.Should().Be(6);
        product.ProductName.Should().Be("Samsung 1TB M.2 PCIe NVMe 980");
        product.ProductDescription.Should()
            .Be("Dysk SSD o pojemności 1TB, format M.2, zapis - 3000MB/s, odczyt - 3500MB/s");
        product.ProductImageUrl.Should().Be("https://cdn.x-kom.pl/i/setup/images/prod/big/product-new-big,,2021/3/pr_2021_3_19_14_10_58_225_00.jpg");
    }
}