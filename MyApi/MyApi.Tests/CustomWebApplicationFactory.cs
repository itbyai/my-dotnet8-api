using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApi.Services;

namespace MyApi.Tests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");
        
        builder.ConfigureServices(services =>
        {
            // 如果需要，这里可以替换服务为测试用的模拟实现
            // 例如:
            // var weatherServiceDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IWeatherService));
            // if (weatherServiceDescriptor != null)
            // {
            //     services.Remove(weatherServiceDescriptor);
            //     services.AddScoped<IWeatherService, TestWeatherService>();
            // }
        });
    }
    
}