namespace ShoeStore.Domain.DTOs.AdminSide.Category;

public class CategoryListDTO
{
    public int ParentCategoryId { get; set; }
    public string ParentCategoryName { get; set; }
    public ICollection<ChildCategoryListDTO>? ChildCategories { get; set; }
}
