﻿using ShoeStore.Domain.DTOs.AdminSide.Role;

namespace ShoeStore.Domain.DTOs.AdminSide.User;

public record ListOfUsersDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mobile { get; set; }
    public DateTime CreateDate { get; set; }
    public string? UserAvatar { get; set; }

    public List<string>? RoleTitles { get; set; }
}

