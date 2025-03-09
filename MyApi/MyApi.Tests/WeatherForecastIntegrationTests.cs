using System.Net;
using System.Text.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using MyApi.Models;
using RestSharp;

namespace MyApi.Tests;

public class WeatherForecastIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public WeatherForecastIntegrationTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetWeatherForecast_ReturnsSuccessAndForecastData()
    {
        // Arrange
        var httpClient = _factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false,
            BaseAddress = new Uri("http://localhost:5246")
        });
        
        var restClient = new RestClient(httpClient);
        var request = new RestRequest("WeatherForecast");

        // Act
        var response = await restClient.ExecuteAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNullOrEmpty();
        
        var forecasts = JsonSerializer.Deserialize<List<WeatherForecast>>(
            response.Content!,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
        
        forecasts.Should().NotBeNull();
        forecasts!.Count.Should().Be(5);
    }
}