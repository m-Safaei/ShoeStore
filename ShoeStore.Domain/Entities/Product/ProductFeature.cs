using ShoeStore.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.Entities.Product;

public class ProductFeature : BaseEntity
{
    public string FeatureTitle { get; set; }
    public string FeatureDescription { get; set; }

    [Required]
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
