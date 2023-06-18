using HeroesDB.Entity;
using Microsoft.EntityFrameworkCore;
using HeroesDAL.Interfaces;
using HeroesDAL.MongodbServices;
using HeroesDB.Sqldb;
using HeroesWeatherService.Interface;
using HeroWeatherService;
using HeroesWeatherService.Config;
using dotenv.net;
using MongoDB.Driver;

var MyAllowedSpecificOrigins = "_myAllowedSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();
var envKeys = DotEnv.Read();

var mongoConnectionString = envKeys["ConnectionString"];
var mongoDatabaseName = envKeys["DatabaseName"];
var mongoCollectionName = envKeys["CollectionName"];

var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);
var mongoCollection = mongoDatabase.GetCollection<Hero>(mongoCollectionName);
builder.Services.AddSingleton(mongoCollection);
var openweathermapKey = builder.Configuration.GetSection("OpenWeather").Get<OpenWeather>();
if (openweathermapKey != null)
{
    var _weatherApiKey = openweathermapKey.ApiKey;
}
builder.Services.AddHttpClient();
builder.Services.AddScoped<IHeroRepository, MongoHeroService>();
builder.Services.AddScoped<IWeatherService, OpenWeatherService>();
builder.Services.AddDbContext<HeroContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HeroContext")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowedSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("https://tourofheroesbackendtjabane.azurewebsites.net/api/heroes")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "";
    });
}

//app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(MyAllowedSpecificOrigins);
app.MapControllers();

app.Run();
