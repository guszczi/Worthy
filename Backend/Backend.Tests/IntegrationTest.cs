using backend;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Backend.Tests;

public class IntegrationTest
{
    protected readonly HttpClient TestClient;

    protected IntegrationTest()
    {
        var appFactory = new WebApplicationFactory<Startup>();
        TestClient = appFactory.CreateClient();
    }
}