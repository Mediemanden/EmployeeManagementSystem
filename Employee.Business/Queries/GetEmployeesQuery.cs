using Employee.Business.Models;
using Employee.Business.Queries.Interfaces;
using Employee.DataAccess.Interfaces;
using Employee.DataAccess.Storage.Interfaces;

namespace Employee.Business;

public class GetEmployeesQuery : IGetEmployeesQuery
{
    private readonly IEmployeeStorageWithMemoryCache _employeeStorage;

    public GetEmployeesQuery(IEmployeeStorageWithMemoryCache employeeStorage)
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
