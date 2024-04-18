using ShoeStore.Domain.Entities.Product;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.DTOs.AdminSide.Product;

public class ProductDetailsDTO
{
    public int ProductId {  get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public string? ProductImage { get; set; }
    [Required]
    public int Price { get; set; }
    [Range(0, 100)]
    public int DiscountPercentage { get; set; }
    public int ProductCategoryId { get; set; }
    public string? ProductCategoryName { get; set; }
    public List<ProductItemAdminSideDTO>? ProductItemDTOs { get; set; }
    public List<ProductFeatureAdminSideDTO>? ProductFeatureDTOs { get; set; }
}
