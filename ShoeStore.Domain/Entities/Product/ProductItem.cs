using ShoeStore.Domain.Common;
using ShoeStore.Domain.Entities.Order;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.Entities.Product;

public class ProductItem : BaseEntity
{

    [Required]
    public int Count { get; set; }

    public bool IsDelete { get; set; }

    [Required]
    public int SizeId { get; set; }
    public Size? Size { get; set; }

    [Required]
    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public List<OrderItem>? OrderItems { get; set; }
}
