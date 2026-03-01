using Application.Service;

var builder = WebApplication.CreateBuilder(args);

// HTTP client configuration to fetch movie locations (JSON endpoint)
builder.Services.AddHttpClient("MovieLocationMap", client =>
{
    client.BaseAddress = new Uri("https://data.sfgov.org/resource/yitu-d5am.json");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// caching and dependency injection
builder.Services.AddMemoryCache();
builder.Services.AddScoped<MovieLocationService>();

// add controllers support
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();