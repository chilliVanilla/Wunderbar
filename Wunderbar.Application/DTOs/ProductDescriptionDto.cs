namespace Wunderbar.Application.DTOs;

public class ProductDescriptionDto
{
    // public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Category { get; set; }
    public required decimal Price { get; set; }
    public int StockCount { get; set; }
    public string? ProductDescription { get; set; }
    
    // public bool? IsAvailable { get; set; }
}