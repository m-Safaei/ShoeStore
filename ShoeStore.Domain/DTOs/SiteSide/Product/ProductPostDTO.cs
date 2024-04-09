namespace ShoeStore.Domain.DTOs.SiteSide.Product;

public class ProductPostDTO
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string? ProductImage { get; set; }
    public int Price { get; set; }
    public int DiscountPercentage { get; set; }
}
