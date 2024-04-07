using ShoeStore.Domain.Common;

namespace ShoeStore.Domain.Entities.Product;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ProductImage { get; set; }
    public bool IsDelete { get; set; }

    public int ProductCategoryId { get; set; }
    public ProductCategory.ProductCategory? ProductCategory { get; set; }

    public List<ProductItem>? productItems { get; set; }
}
