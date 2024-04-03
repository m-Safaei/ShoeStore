using ShoeStore.Domain.Entities.Product;

namespace ShoeStore.Domain.Entities.Color_Size;

public class Material
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<ProductItem>? ProductItems { get; set; }
}
