
using Microsoft.EntityFrameworkCore;
using Wunderbar.Application.Interfaces;
using Wunderbar.Infrastructure.Data;
using Wunderbar.Application.Services;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("Hello World!!!!!!!!!!!!!!!!!!!!");

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>
    (options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("MainDb"))
        );


builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSingleton<IAutoCompleteService, AutoCompleteService>();
builder.Services.AddHostedService<TrieLoadingService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

