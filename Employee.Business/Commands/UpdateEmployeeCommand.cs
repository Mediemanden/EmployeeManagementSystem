using Employee.Business.Models;
using Employee.DataAccess;
using Employee.DataAccess.Interfaces;

namespace Employee.Business;

public class UpdateEmployeeCommand : IUpdateEmployeeCommand
{
    private readonly IEmployeeStorage _employeeStorage;

    public UpdateEmployeeCommand(IEmployeeStorage employeeStorage)
    {
        _employeeStorage = employeeStorage;
    }

    public async Task ExecuteAsync(EmployeeModel request)
    {
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
