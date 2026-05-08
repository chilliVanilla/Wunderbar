using System.ComponentModel.DataAnnotations;

namespace Wunderbar.Domain.Models;

public class Vendor
{
    // [Key]
    public required Guid VendorId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? MiddleName { get; set; }
    public required int Age { get; set; }
    public string? BrandName { get; set; }
    public ICollection<CartItems>? Items { get; set; } = new List<CartItems>();
    public string? IdentityUserId { get; set; }
}