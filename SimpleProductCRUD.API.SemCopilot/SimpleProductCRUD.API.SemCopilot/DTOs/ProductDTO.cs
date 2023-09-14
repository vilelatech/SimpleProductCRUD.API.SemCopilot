﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SimpleProductCRUD.API.SemCopilot.DTOs;

public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Description")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Price")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Stock is required")]
    [Range(1, 9999)]
    [DisplayName("Stock")]
    public int Stock { get; set; }

    [DisplayName("Categories")] public int CategoryId { get; set; }
}