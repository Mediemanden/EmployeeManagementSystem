namespace Employee.DataAccess;

public class EmployeeEntity
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public required string Department { get; set; }
    public string? Email { get; set; }
    public decimal? Salary { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}
