using Employee.Business.Commands.Interfaces;
using Employee.Business.Models;

namespace Employee.Business;

public interface IUpdateEmployeeCommand : ICommand<EmployeeModel>
{

}
