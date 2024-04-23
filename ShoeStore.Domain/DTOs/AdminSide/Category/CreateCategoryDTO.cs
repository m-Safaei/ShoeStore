namespace ShoeStore.Domain.DTOs.AdminSide.Category;

public class CreateCategoryDTO
{
    public string CategoryName { get; set; }
    public int? ParentId { get; set; }
    public string? ParentName { get; set; }
}
