using APBD10.Contexts;
using APBD10.DTOs;
using APBD10.Exceptions;
using APBD10.Models;
using APBD10.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/accounts/{accountId}", async (int id, IAccountService service) => Results.Ok((object?)await service.GetAccountAsync(id)));

app.MapPost("api/products", async (AddProductDTO product, IProductService service) =>
{
    try
    {
        await service.AddProductAsync(product);   
    } catch (AddProductException e)
    {
        return Results.BadRequest(e.Message);
    }
    return Results.Created("api/products", product);
});

app.Run();
