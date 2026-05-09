using Wunderbar.Application.DTOs;

namespace Wunderbar.Application.Interfaces;

public interface IProductService
{
    public void AddNewProduct(ProductDescriptionDto productDto);
    public void GetProductById(int id);
    public void GetProductByName(string name);
    public void GetAllProductsByName(string name);
    public void FindProductsByPriceRange(double rangeStart, double rangeStop);
    public void FindProductsGreaterThanPrice(double priceFloor);
    public void FindProductsLessThanPrice(double priceCeiling);
    public void SortByCategory(string category);
    public void FindAllInCategory(string selectCategory);


}