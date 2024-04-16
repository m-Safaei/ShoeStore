using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.DTOs.AdminSide.Product;

public class ProductItemAdminSideDTO
{
    public int Id { get; set; }
    [Required]
    public int Count { get; set; }

    [Required]
    public int SizeId { get; set; }
    public float SizeNumber { get; set; }

    [Required]
    public int ProductId { get; set; }
}
