using ShoeStore.Domain.DTOs.SiteSide.Product;

namespace ShoeStore.Domain.DTOs.SiteSide.ProductCategory;

public class CategoryPageDTO
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public ICollection<ProductPostDTO>? ProductPostDTOs { get; set; }
    public string? Order { get; set; }
    public int PageNumber { get; set; }
    public int TotalCount { get; set; }
}
