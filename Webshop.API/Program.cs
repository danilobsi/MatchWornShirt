using System.Reflection;
using Webshop.API.Repositories;
using Webshop.API.Services;

var builder = WebApplication.CreateBuilder(args);

//Repositories
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IShoppingCartItemRepository, ShoppingCartItemRepository>();

//Services
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ShoppingCartService>();
builder.Services.AddScoped<IDiscountService, QuantityDiscountService>();
builder.Services.AddScoped<IDiscountService, PercentageDiscountService>();
builder.Services.AddScoped<IDiscountService, CashDiscountService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
