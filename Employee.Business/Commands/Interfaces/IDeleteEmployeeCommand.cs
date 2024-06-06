using Employee.Business.Commands.Interfaces;

namespace Employee.Business;

public interface IDeleteEmployeeCommand : ICommand<Guid>
{

}
