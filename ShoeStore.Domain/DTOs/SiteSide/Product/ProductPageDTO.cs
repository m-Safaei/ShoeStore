using ShoeStore.Domain.Entities.Product;

namespace ShoeStore.Domain.DTOs.SiteSide.Product;

public class ProductPageDTO
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string MaterialTitle { get; set; }
    public List<string>? ProductImages { get; set; }
    public int ProductCategoryId { get; set; }

}
