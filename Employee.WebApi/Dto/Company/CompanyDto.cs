using System.ComponentModel.DataAnnotations;

namespace Employee.WebApi;

public class CompanyDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Address { get; set; }
    public Guid? ParentCompanyId { get; set; }
}
