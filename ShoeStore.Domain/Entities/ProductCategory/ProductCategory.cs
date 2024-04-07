using ShoeStore.Domain.Common;
using ShoeStore.Domain.Entities.Product;

namespace ShoeStore.Domain.Entities.ProductCategory;

public class ProductCategory : BaseEntity
{
    public string Title { get; set; }
    public int? ParentId { get; set; }
    public bool IsDelete {  get; set; }

    public List<Product.Product>? Products { get; set; }

}
