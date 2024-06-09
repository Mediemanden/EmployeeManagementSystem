namespace Employee.Business.Queries.Interfaces;

public interface IQuery<TResult, TRequest>
{
    Task<TResult> ExecuteAsync(TRequest request);
}
