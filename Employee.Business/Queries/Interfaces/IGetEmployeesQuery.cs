using Employee.Business.Models;

namespace Employee.Business;

public interface IGetEmployeesQuery : IQuery<IEnumerable<EmployeeModel>, GetEmployeesRequest>
{

}

public class GetEmployeesRequest
{
    // TODO: create and move from GetEmployeesQuery
}