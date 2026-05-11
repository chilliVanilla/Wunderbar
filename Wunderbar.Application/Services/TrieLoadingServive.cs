using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wunderbar.Application.Interfaces;
using Wunderbar.Infrastructure.Data;

namespace Wunderbar.Application.Services;
using Microsoft.Extensions.Hosting;

public class TrieLoadingService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IAutoCompleteService _autoCompleteService;

    public TrieLoadingService(IServiceProvider serviceProvider, IAutoCompleteService autoCompleteService)
    {
        _autoCompleteService = autoCompleteService;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var products = await dbContext.Products
                .Select(p => new { p.Name, p.ProductId })
                .AsNoTracking()
                .ToListAsync(stoppingToken);

            foreach (var product in products)
            {
                _autoCompleteService.InsertNewProduct(product.Name, product.ProductId);
            }
        }
    }
}