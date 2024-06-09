using System.ComponentModel.DataAnnotations;

namespace Employee.WebApi;

public class EmployeeDto
{
    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Department { get; set; }

    public string? Email { get; set; }

    [Range(1, double.MaxValue)]
    public decimal? Salary { get; set; }
}
