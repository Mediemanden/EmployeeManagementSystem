using Employee.Business.Models;

namespace Employee.Business.Queries.Interfaces;

public interface IGetEmployeeQuery : IQuery<EmployeeModel, Guid>
{

}
