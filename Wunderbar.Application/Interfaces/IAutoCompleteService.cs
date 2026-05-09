namespace Wunderbar.Application.Interfaces;
using Wunderbar.Domain;

public interface IAutoCompleteService
{
    public void InsertNewProduct(string productName, int popularityScore);
    public List<string> GetTopSuggestions(string query);
}