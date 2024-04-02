using ShoeStore.Domain.Common;

namespace ShoeStore.Domain.Entities.ProductCategory;

public class ProductCategory : BaseEntity
{
    public string Title { get; set; }
    public int? ParentId { get; set; }
    public bool IsDelete {  get; set; }

}
