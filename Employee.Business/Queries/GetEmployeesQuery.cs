using Employee.Business.Models;
using Employee.Business.Queries.Interfaces;
using Employee.DataAccess.Interfaces;

namespace Employee.Business;

public class GetEmployeesQuery : IGetEmployeesQuery
{
    private readonly IEmployeeStorage _employeeStorage;

    public GetEmployeesQuery(IEmployeeStorage employeeStorage)
    {
        _employeeStorage = employeeStorage;
    }

    public async Task<IEnumerable<EmployeeModel>> ExecuteAsync(SearchEmployeesRequest _)
    {
        List<DataAccess.EmployeeEntity> employees = await _employeeStorage.GetEmployeesAsync();

        return employees.Select(employee => new EmployeeModel
        {
            Id = employee.Id,
            FullName = employee.FullName,
            Email = employee.Email,
            DateOfBirth = employee.DateOfBirth,
            Department = employee.Department,
            Salary = employee.Salary,
        });
    }
}
