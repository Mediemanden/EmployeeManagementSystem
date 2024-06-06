using Employee.Business.Models;

namespace Employee.Business;

public class GetEmployeesQuery : IGetEmployeesQuery
{
    public Task<IEnumerable<EmployeeModel>> ExecuteAsync(GetEmployeesRequest request)
    {
        throw new NotImplementedException();
    }
}
