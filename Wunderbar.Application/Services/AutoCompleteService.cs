using Wunderbar.Application.Interfaces;
using Wunderbar.Domain.Models;

namespace Wunderbar.Application.Services;

public class AutoCompleteService : IAutoCompleteService
{
    private readonly TrieNode _root;

    public AutoCompleteService(TrieNode root)
    {
        _root = root;
    }
    


    public void InsertNewProduct(string productName, int popularityScore)
    {
        // var currentPointer = _root;
        productName = productName.ToLower().Trim();
        string[] words = productName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            var currentNode = _root;
            foreach (char symbol in word)
            {
                currentNode = currentNode.Children.GetOrAdd(symbol, _ => new TrieNode());
                currentNode.UpdateTopSuggestions(word, popularityScore);
            }

            currentNode.IsEndOfWord = true;
        }
        var currentNode1 = _root;
        foreach (char symbol in productName)
        {
            currentNode1 = currentNode1.Children.GetOrAdd(symbol, _ => new TrieNode());
            currentNode1.UpdateTopSuggestions(productName, popularityScore);
        }

        currentNode1.IsEndOfWord = true;
        
    }

    public List<string> GetTopSuggestions(string query)
    {
        var normalizedQuery = query.ToLower().Trim();
        var currentNode = _root;
        foreach (var symbol in normalizedQuery)
        {
            if (!currentNode.Children.TryGetValue(symbol, out var newNode))
            {
                return new List<string>();
            }
            
            currentNode = newNode;
        }

        return currentNode.TopSuggestionscache.Keys.ToList();
    }
}