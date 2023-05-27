using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Repository;
using MinhaApi.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection String
builder.Services.AddDbContext<ProductDBContext>
    (options => options.UseMySql(
        "Server=localhost;initial catalog=DB_Product;Uid=root",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql")));

// Dependence Injection
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IAboutProductRepository, AboutProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
