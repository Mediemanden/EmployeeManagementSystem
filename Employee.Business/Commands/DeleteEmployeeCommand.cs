
using Employee.DataAccess.Interfaces;

namespace Employee.Business;

public class DeleteEmployeeCommand : IDeleteEmployeeCommand
{
    readonly IEmployeeStorage _employeeStorage;

    public DeleteEmployeeCommand(IEmployeeStorage employeeStorage)
    {
        _employeeStorage = employeeStorage;
    }

    public async Task ExecuteAsync(Guid request)
    {
        await _employeeStorage.DeleteEmployeeAsync(request);
    }
}
