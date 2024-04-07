using ShoeStore.Domain.Common;

namespace ShoeStore.Domain.Entities.Product;

public class ProductFeature : BaseEntity
{
    public string FeatureTitle { get; set; }
    public string FeatureDescription { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
