using Employee.Business.Models;

namespace Employee.Business;

public class GetEmployeeQuery : IGetEmployeeQuery
{
    public Task<EmployeeModel> ExecuteAsync(Guid request)
    {
        throw new NotImplementedException();
    }
}
