namespace Employee.Business.Models;

public class EmployeeModel
{
    public required Guid Id { get; init; }
    public required string FullName { get; init; }
    public required DateTime DateOfBirth { get; init; }
    public required string Department { get; init; }
    public string? Email { get; init; }
    public decimal? Salary { get; init; }
    public int Age => DateTime.Now.Year - DateOfBirth.Year; // TODO fix birthday calculation
}