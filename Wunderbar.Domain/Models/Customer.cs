namespace Wunderbar.Domain.Models;

public class Customer
{
    public required Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? MiddleName { get; set; }
    public required int? Age { get; set; }
    
}