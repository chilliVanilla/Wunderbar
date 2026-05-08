using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wunderbar.Domain.Models;

public class CartItems
{
    // [Key]
    public int CartItemsId { get; set; }
    
    public required Guid CustomerId { get; set; }
    
    [ForeignKey("CustomerId")]
    public Customer customer { get; set; } = null!;


    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
}