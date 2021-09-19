using Microsoft.OpenApi.Models;
using Warehouse.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddWarehouseServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Warehouse.Api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Warehouse.Api v1"));
}

app.UseWearhouseServices();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
