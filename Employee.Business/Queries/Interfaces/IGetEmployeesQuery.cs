using Employee.Business.Models;

namespace Employee.Business.Queries.Interfaces;

public interface IGetEmployeesQuery : IQuery<IEnumerable<EmployeeModel>, SearchEmployeesRequest>
{

}