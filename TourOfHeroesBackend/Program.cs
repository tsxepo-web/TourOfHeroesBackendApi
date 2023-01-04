using HeroesDB.Entity;
using Microsoft.EntityFrameworkCore;
using HeroesDAL;
using HeroesDAL.Interfaces;
using HeroesDB.Mongodb;
using HeroesDAL.MongodbServices;
using Microsoft.Extensions.Options;
using HeroesDB.Sqldb;
using HeroesDAL.SqlServices;
using Microsoft.NET.StringTools;
using HeroesWeatherService;
using HeroesWeatherService.Interface;
using HeroWeatherService;
using HeroesWeatherService.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var openWeatherConfig = builder.Configuration.GetSection("OpenWeather");
builder.Services.Configure<OpenWeather>(openWeatherConfig);
builder.Services.AddHttpClient();
builder.Services.AddScoped<IHeroRepository, SqlHeroService>();
builder.Services.AddScoped<IWeatherService, OpenWeatherService>();
builder.Services.AddDbContext<HeroContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HeroContext")));
builder.Services.Configure<HeroesDatabaseSettings>(builder.Configuration.GetSection("HeroesDatabaseSettings"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("https://localhost:7179/api/Heroes")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
       
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("MyAllowedSpecificOrigins");
app.MapControllers();

app.Run();
