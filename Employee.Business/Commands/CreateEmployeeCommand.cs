using Employee.Business.Models;
using Employee.DataAccess;
using Employee.DataAccess.Interfaces;

namespace Employee.Business.Commands;

public class CreateEmployeeCommand : ICreateEmployeeCommand
{
    private readonly IEmployeeStorage _employeeStorage;

    public CreateEmployeeCommand(IEmployeeStorage employeeStorage)
    {
        _employeeStorage = employeeStorage;
    }

    public Task ExecuteAsync(EmployeeModel request)
    {
        // Validate create employee request -- Will throw an exception if invalid
        EmployeeValidator.ValidateEmployee(request);

        var employee = new EmployeeEntity
        {
            Id = request.Id,
            FullName = request.FullName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth,
            Department = request.Department,
            Salary = request.Salary,
        };

        return _employeeStorage.CreateEmployeeAsync(employee);
    }
}
