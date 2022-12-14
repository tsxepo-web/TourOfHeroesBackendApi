using HeroesDB.Entity;
using Microsoft.EntityFrameworkCore;
using HeroesDAL;
using HeroesDAL.Interfaces;
using HeroesDB.Mongodb;
using HeroesDAL.MongodbServices;
using Microsoft.Extensions.Options;
using HeroesDB.Sqldb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IHeroRepository, MongoHeroService>();
builder.Services.AddSingleton<MongoHeroService>();
builder.Services.AddDbContext<HeroContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HeroContext")));
builder.Services.Configure<HeroesDatabaseSettings>(builder.Configuration.GetSection("HeroesDatabaseSettings"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
