﻿using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.DTOs.AdminSide.Role;

public class RoleDto
{
    public int RoleId { get; set; }

    [StringLength(100, MinimumLength = 3)]
    public string RoleTitle { get; set; }

    [StringLength(100, MinimumLength = 3)]
    public string RoleUniqueName { get; set; }

    public DateTime CreateDate { get; set; }
}

