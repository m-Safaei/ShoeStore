﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.DTOs.AdminSide.Product;

public class CreateProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public IFormFile? ProductImageFile { get; set; }
    public string? OldProductImage {  get; set; }

    [Required]
    public int Price { get; set; }

    [Range(0, 100)]
    public int DiscountPercentage { get; set; }
    [Required]
    public int ProductCategoryId { get; set; }
}
