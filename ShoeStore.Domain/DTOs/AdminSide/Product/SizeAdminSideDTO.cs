using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.DTOs.AdminSide.Product;

public class SizeAdminSideDTO
{
    public int Id { get; set; }
    [Required]
    public float SizeNumber {  get; set; }
}
