using Microsoft.EntityFrameworkCore;
using MovieFlix.Api.Data;
using MovieFlix.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddDbContext<MovieFlixDbContext>(options =>
    options.UseSqlite("Data Source=MovieLix.db"));

builder.Services.AddScoped<IMovieService, MovieService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();