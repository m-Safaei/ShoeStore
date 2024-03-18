using ShoeStore.Domain.Common;
using ShoeStore.Domain.Entities.Color_Size;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.Entities.Product;

public class ProductItem : BaseEntity
{
    [Required]
    public int Price { get; set; }

    [Range(0, 100)]
    public int DiscountPercentage { get; set; }

    [Required]
    public int Count { get; set; }

    public string? ProductItemImage { get; set; }
    public bool IsDelete { get; set; }

    [Required]
    public int ColorId { get; set; }
    public Color? Color { get; set; }

    [Required]
    public int SizeId { get; set; }
    public Size? Size { get; set; }

    [Required]
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
