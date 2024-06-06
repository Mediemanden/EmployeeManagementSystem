using Employee.Business.Models;

namespace Employee.Business.Commands;

public class CreateEmployeeCommand : ICreateEmployeeCommand
{
    public Task ExecuteAsync(EmployeeModel request)
    {
        throw new NotImplementedException();
    }
}
