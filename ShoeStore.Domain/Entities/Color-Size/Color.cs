using ShoeStore.Domain.Common;

namespace ShoeStore.Domain.Entities.Color_Size;

public class Color : BaseEntity
{
    public string ColorName { get; set; }
    public bool IsDelete { get; set; }
}
