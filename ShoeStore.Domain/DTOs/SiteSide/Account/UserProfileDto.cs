﻿using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.DTOs.SiteSide.Account;
public class UserProfileDto
{
    public int Id { get; set; }
    public string Mobile { get; set; }
    public string? UserAvatar { get; set; }
}

