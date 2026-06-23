using ModularMonolith.Core.DependencyInjection;
using ModularMonolith.Delivery.DependencyInjection;
using ModularMonolith.Financial.DependencyInjection;
using ModularMonolith.Products.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddModuleCore();
builder.Services.AddProducts();
builder.Services.AddFinancial();
builder.Services.AddDelivery();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseProductsMigrations();
app.UseFinancialMigrations();
app.UseDeliveryMigrations();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
