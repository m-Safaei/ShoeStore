namespace ShoeStore.Domain.DTOs.SiteSide.ProductCategory;

public class ParentCategoryDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<CategoryDTO> ChildCategories { get; set; }
}
