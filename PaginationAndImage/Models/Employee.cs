using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginationAndImage.Models;

[Table("employee")]
public class Employee
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }

    public required int Age { get; set; }
    public string? Photo { get; set; }

    public  IFormFile? File { get; set; }
}