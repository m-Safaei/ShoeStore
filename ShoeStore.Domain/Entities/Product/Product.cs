using ShoeStore.Domain.Common;
using ShoeStore.Domain.Entities.Category;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.Entities.Product;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<string>? ProductImages { get; set; }
    public bool IsDelete { get; set; }

    public List<int>? ProductCategoryId { get; set; }
    public List<ProductCategory>? ProductCategories {  get; set; }
    public List<int>? ProductItemId { get; set; }
    public List<ProductItem>? productItems { get; set; }
}
