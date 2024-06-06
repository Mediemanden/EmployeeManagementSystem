namespace Employee.WebApi;

public class EmployeeDto
{
    public required string Name { get; set; }
    public required string Department { get; set; }
    public string? Email { get; set; }
    public decimal? Salary { get; set; }
}
