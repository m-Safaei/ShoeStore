using ShoeStore.Domain.DTOs.SiteSide.Comment;

namespace ShoeStore.Domain.DTOs.SiteSide.Product;

public class ProductPageDTO
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? ProductImage { get; set; }
    public ICollection<ProductFeatureDTO>? ProductFeatureDTOs { get; set; }
    public int ProductCategoryId { get; set; }
    public int Price { get; set; }
    public int DiscountPercentage { get; set; }
    public ICollection<SizeDTO>? SizeDTOs { get; set; }
}
