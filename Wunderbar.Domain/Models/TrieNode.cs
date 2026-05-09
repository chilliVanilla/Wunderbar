using System.Collections.Concurrent;

namespace Wunderbar.Domain.Models;

public class TrieNode
{
    public bool IsEndOfWord { get; set; }
    public ConcurrentDictionary<char, TrieNode> Children { get; set; } = new();
    public int PopularityScore { get; set; }
    public Dictionary<string, int> TopSuggestionscache { get; set; } = new();

    public void UpdateTopSuggestions(string productName, int score)
    {
        TopSuggestionscache[productName] = score;

        if (TopSuggestionscache.Count <= 5) return;
        var lowestScoringItem = TopSuggestionscache.OrderBy(x => x.Value).First();
        TopSuggestionscache.Remove(lowestScoringItem.Key);
    }
}