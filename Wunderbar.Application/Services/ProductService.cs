using Wunderbar.Application.DTOs;
using Wunderbar.Application.Interfaces;
using Wunderbar.Infrastructure.Data;

namespace Wunderbar.Application.Services;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _dbContext;

    public ProductService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public void AddNewProduct(ProductDescriptionDto productDto)
    {
        
    }

    public void GetProductById(int id)
    {
        
    }

    public void GetProductByName(string name)
    {
        
    }

    public void GetAllProductsByName(string name)
    {
        
    }

    public void FindProductsByPriceRange(double rangeStart, double rangeStop)
    {
        
    }

    public void FindProductsGreaterThanPrice(double priceFloor)
    {
        
    }

    public void FindProductsLessThanPrice(double priceCeiling)
    {
        
    }

    public void SortByCategory(string category)
    {
        
    }

    public void FindAllInCategory(string selectCategory)
    {
        
    }

}