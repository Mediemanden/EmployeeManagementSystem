namespace Employee.WebApi;

public class GetEmployeeDto : EmployeeDto
{
    public required Guid Id { get; set; }
    public required int Age { get; set; }
}
