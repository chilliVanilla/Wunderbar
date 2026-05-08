using System.ComponentModel.DataAnnotations;

namespace Wunderbar.Domain.Models;

public class Customer
{
    // [Key]
    public required Guid CustomerId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? EmailAddress { get; set; }
    //should email be nullable?
    public required int? Age { get; set; }
    public ICollection<CartItems>? Items { get; set; } = new List<CartItems>();
    public string? IdentityUserId { get; set; }
    // public string Address { get; set; }
    
}