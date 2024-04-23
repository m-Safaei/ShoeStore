namespace ShoeStore.Domain.DTOs.AdminSide.Product;

public class ProductListDTO
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int DiscountPercentage { get; set; }
    public string ProductCategoryName { get; set; }
    public string? ProductImage { get; set; }

}
