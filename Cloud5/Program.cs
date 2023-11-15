using Cloud5.API.Middlewares;
using Cloud5.Domain;
using Cloud5.Repository;
using Cloud5.Service;
using Cloud5.Service.Implementation;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CloudDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
               ServiceLifetime.Scoped,
               ServiceLifetime.Scoped);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddControllers();
builder.Services.AddTransient<CloudMiddleware>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
await app.ImportPlayerStats("L9HomeworkChallengePlayersInput.csv");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<CloudMiddleware>();
app.MapControllers();

app.Run();
