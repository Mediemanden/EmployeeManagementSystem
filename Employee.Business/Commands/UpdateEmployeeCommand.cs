using Employee.Business.Models;
using Employee.DataAccess;
using Employee.DataAccess.Interfaces;
using Employee.DataAccess.Storage.Interfaces;

namespace Employee.Business;

public class UpdateEmployeeCommand : IUpdateEmployeeCommand
{
    private readonly IEmployeeStorageWithMemoryCache _employeeStorage;

    public UpdateEmployeeCommand(IEmployeeStorageWithMemoryCache employeeStorage)
    {
        _employeeStorage = employeeStorage;
    }

    public async Task ExecuteAsync(EmployeeModel request)
    {
        // Validate update employee request -- Will throw an exception if invalid
        EmployeeValidator.ValidateEmployee(request);

        EmployeeEntity? employeeEntity = await _employeeStorage.GetEmployeeAsync(request.Id);

        if (employeeEntity == null)
        {
            throw new Exception("Employee not found");
        }

        employeeEntity.DateOfBirth = request.DateOfBirth;
        employeeEntity.Department = request.Department;
        employeeEntity.Email = request.Email;
        employeeEntity.FullName = request.FullName;
        employeeEntity.Salary = request.Salary;

        await _employeeStorage.UpdateEmployeeAsync(employeeEntity);
    }
}
