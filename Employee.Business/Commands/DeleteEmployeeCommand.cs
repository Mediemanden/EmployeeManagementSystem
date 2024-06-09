
using Employee.DataAccess.Interfaces;
using Employee.DataAccess.Storage.Interfaces;

namespace Employee.Business;

public class DeleteEmployeeCommand : IDeleteEmployeeCommand
{
    readonly IEmployeeStorageWithMemoryCache _employeeStorage;

    public DeleteEmployeeCommand(IEmployeeStorageWithMemoryCache employeeStorage)
    {
        _employeeStorage = employeeStorage;
    }

    public async Task ExecuteAsync(Guid request)
    {
        await _employeeStorage.DeleteEmployeeAsync(request);
    }
}
