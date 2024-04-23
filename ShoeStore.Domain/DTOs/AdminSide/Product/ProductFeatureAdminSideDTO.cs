using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.DTOs.AdminSide.Product;

public class ProductFeatureAdminSideDTO
{
    public int Id { get; set; }
    public string FeatureTitle { get; set; }
    public string FeatureDescription { get; set; }

    [Required]
    public int ProductId { get; set; }
}
