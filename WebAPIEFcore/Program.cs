using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPIEFcore.Data;
using WebAPIEFcore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();

// Adicione o serviço PovoaBanco ao contêiner de injeção de dependência
builder.Services.AddTransient<PovoaBanco>();

// ...

var app = builder.Build();

// Configure the HTTP request pipeline.
// ...
app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    var dbContext = serviceProvider.GetRequiredService<AppDbContext>();

    // Check if there are any products in the database
    if (!dbContext.Products.Any())
    {
        var povoaBanco = serviceProvider.GetRequiredService<PovoaBanco>();
        povoaBanco.PopularBaseDeDados();
    }
}

app.MapGet("/products", async (AppDbContext context) =>
{
    var products = await context.Products.ToListAsync();

    return Results.Ok(products);
});

app.MapGet("/products/{id}", (int id, AppDbContext context) =>
{
    var product = context.Products.FirstOrDefault(p => p.ProductId == id);

    if (product == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(product);
});

app.MapPost("/products", async (Product product, AppDbContext context) =>
{
    var productService = context.Products;

    // You should validate the incoming product data here if necessary

    // Add the product to the DbSet
    productService.Add(product);
    await context.SaveChangesAsync();

    return Results.Created($"/products/{product.ProductId}", product);
});

app.MapPut("/products/{id}", async (int id, Product product, AppDbContext context) =>
{
    var existingProduct = await context.Products.FindAsync(id);

    if (existingProduct == null)
    {
        return Results.NotFound();
    }

    existingProduct.Nome = product.Nome;
    existingProduct.Preco = product.Preco;
    existingProduct.Quantidade = product.Quantidade;

    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/products/{id}", async (int id, AppDbContext context) =>
{
    var product = await context.Products.FindAsync(id);

    if (product == null)
    {
        return Results.NotFound();
    }

    context.Products.Remove(product);
    await context.SaveChangesAsync();

    return Results.NoContent();
});


//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();