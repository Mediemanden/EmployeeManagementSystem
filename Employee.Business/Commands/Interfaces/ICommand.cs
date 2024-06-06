namespace Employee.Business.Commands.Interfaces;

public interface ICommand<TRequest>
{
    Task ExecuteAsync(TRequest request);
}
