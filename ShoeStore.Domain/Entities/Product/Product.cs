using ShoeStore.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.Entities.Product;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? ProductImage { get; set; }
    [Required]
    public int Price { get; set; }
    [Range(0, 100)]
    public int DiscountPercentage { get; set; }
    public bool IsDelete { get; set; }
    public int ProductCategoryId { get; set; }
    public ProductCategory.ProductCategory? ProductCategory { get; set; }
    public List<ProductItem>? ProductItems { get; set; }
    public List<ProductFeature>? ProductFeatures { get; set; }
}
