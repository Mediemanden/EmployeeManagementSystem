using Employee.Business.Models;
using Employee.Business.Queries.Interfaces;
using Employee.DataAccess.Interfaces;
using Employee.DataAccess.Storage.Interfaces;

namespace Employee.Business;

public class SearchEmployeesQuery : ISearchEmployeesQuery
{
    private readonly IEmployeeStorageWithMemoryCache _employeeStorage;

    public SearchEmployeesQuery(IEmployeeStorageWithMemoryCache employeeStorage)
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
