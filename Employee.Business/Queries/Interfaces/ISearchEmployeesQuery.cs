using Employee.Business.Models;

namespace Employee.Business.Queries.Interfaces;

public interface ISearchEmployeesQuery : IQuery<IEnumerable<EmployeeModel>, SearchEmployeesRequest>
{

}
