using System.ComponentModel.DataAnnotations;

namespace Wunderbar.Domain.Models;

public class Product
{
    // [Key]
    public int ProductId { get; set; }
    public required string Name { get; set; }
    public required string Category { get; set; }
    public required decimal Price { get; set; }
    public DateTime AddedAt { get; set; }
    public bool InStock { get; set; }
    public string? ProductDescription { get; set; }
    public int StockCount { get; set; }
    public DateTime? DateLastRequested { get; set; }
}