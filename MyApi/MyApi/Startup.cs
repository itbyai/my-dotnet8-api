// using MyApi.Services;

// namespace MyApi;

// // 实现标记接口
// public class Startup : Tests.IApiMarker
// {
//     public IConfiguration Configuration { get; }

//     public Startup(IConfiguration configuration)
//     {
//         Configuration = configuration;
//     }

//     public void ConfigureServices(IServiceCollection services)
//     {
//         // Add services to the container.
//         services.AddControllers();
//         services.AddEndpointsApiExplorer();
//         services.AddSwaggerGen();

//         // Register our services
//         services.AddScoped<IWeatherService, WeatherService>();
//     }

//     public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//     {
//         // Configure the HTTP request pipeline.
//         if (env.IsDevelopment())
//         {
//             app.UseSwagger();
//             app.UseSwaggerUI();
//         }

//         app.UseHttpsRedirection();
//         app.UseAuthorization();
//         app.UseRouting();
//         app.UseEndpoints(endpoints =>
//         {
//             endpoints.MapControllers();
//         });
//     }
// }