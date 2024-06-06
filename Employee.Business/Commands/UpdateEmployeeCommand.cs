using Employee.Business.Models;

namespace Employee.Business;

public class UpdateEmployeeCommand : IUpdateEmployeeCommand
{
    public Task ExecuteAsync(EmployeeModel request)
    {
        throw new NotImplementedException();
    }
}
