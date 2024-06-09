using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Employee.WebApi;

public class EmployeeDto
{
    [Required]
    [DefaultValue("John Doe")]
    public required string Name { get; set; }

    [Required]
    [DefaultValue("IT")]
    public required string Department { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? Salary { get; set; }
}
