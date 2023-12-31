﻿using System.ComponentModel.DataAnnotations;

namespace SimpleProductCRUD.API.SemCopilot.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; set; }
}