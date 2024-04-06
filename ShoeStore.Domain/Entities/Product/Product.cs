using ShoeStore.Domain.Common;
using ShoeStore.Domain.Entities.Color_Size;
using ShoeStore.Domain.Entities.ProductCategory;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.Entities.Product;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<string>? ProductImages { get; set; }
    public bool IsDelete { get; set; }

    public int ProductCategoryId { get; set; }
    public ProductCategory.ProductCategory? ProductCategory { get; set; }

    [Required]
    public int MaterialId { get; set; }
    public Material? Material { get; set; }

    public List<ProductItem>? productItems { get; set; }
}
