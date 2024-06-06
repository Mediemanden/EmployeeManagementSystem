using Employee.Business.Models;

namespace Employee.Business;

public interface IGetEmployeeQuery : IQuery<EmployeeModel, Guid>
{

}
