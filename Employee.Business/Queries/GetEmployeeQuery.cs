using Employee.Business.Models;
using Employee.DataAccess.Interfaces;

namespace Employee.Business;

public class GetEmployeeQuery : IGetEmployeeQuery
{
    private readonly IEmployeeStorage _employeeStorage;

    public GetEmployeeQuery(IEmployeeStorage employeeStorage)
    {
        _employeeStorage = employeeStorage;
    }

    public async Task<EmployeeModel> ExecuteAsync(Guid request)
    {
        var employee = await _employeeStorage.GetEmployeeAsync(request);

        if (employee == null)
        {
            throw new Exception("Employee not found");
        }

        return new EmployeeModel
        {
            Id = employee.Id,
            FullName = employee.FullName,
            Email = employee.Email,
            DateOfBirth = employee.DateOfBirth,
            Department = employee.Department,
            Salary = employee.Salary,
        };
    }
}
