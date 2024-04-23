using ShoeStore.Domain.DTOs.SiteSide.ProductCategory;

namespace ShoeStore.Domain.DTOs.SiteSide.Product;

public class ProductPageBreadCrumbDTO
{
    public CategoryDTO ChildCategory { get; set; }
    public CategoryDTO ParentCategory { get; set; }
}
