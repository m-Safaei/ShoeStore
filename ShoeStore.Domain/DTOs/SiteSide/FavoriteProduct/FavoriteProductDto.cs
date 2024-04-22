namespace ShoeStore.Domain.DTOs.SiteSide.FavoriteProduct;
public record FavoriteProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Image { get; set; }
    public int Price { get; set; }
}

