namespace ShoeStore.Domain.DTOs.SiteSide.Account;

public record UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mobile { get; set; }
    public string Password { get; set; }
    public bool IsDelete { get; set; }
}

