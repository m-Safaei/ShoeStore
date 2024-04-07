using ShoeStore.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.Entities.Product;

public class Size : BaseEntity
{
    [Required]
    public float SizeNumber { get; set; }
    public bool IsDelete { get; set; }
}
