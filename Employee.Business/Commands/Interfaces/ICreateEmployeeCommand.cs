using Employee.Business.Commands.Interfaces;
using Employee.Business.Models;

namespace Employee.Business;

public interface ICreateEmployeeCommand : ICommand<EmployeeModel>
{

}
