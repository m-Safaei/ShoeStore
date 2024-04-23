namespace ShoeStore.Domain.DTOs.AdminSide.Category;

public class EditCategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public DateTime CreateDate { get; set; }
}
