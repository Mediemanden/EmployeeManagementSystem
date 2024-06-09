using System.ComponentModel;

namespace Employee.WebApi;

public class CreateEmployeeDto : EmployeeDto
{
    [DefaultValue("2000-01-01")]
    public DateTime DateOfBirth { get; set; }
}
