using Employee.Business.Models;
using Employee.Business.Queries.Interfaces;
using Employee.DataAccess.Interfaces;

namespace Employee.Business;

public class SearchEmployeesQuery : ISearchEmployeesQuery
{
    private readonly IEmployeeStorage _employeeStorage;

    public SearchEmployeesQuery(IEmployeeStorage employeeStorage)
    {
        _employeeStorage = employeeStorage;
    }

    public async Task<IEnumerable<EmployeeModel>> ExecuteAsync(SearchEmployeesRequest request)
    {
        List<DataAccess.EmployeeEntity> employees = await _employeeStorage.SearchEmployeesAsync(request.Name, request.Department);

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
