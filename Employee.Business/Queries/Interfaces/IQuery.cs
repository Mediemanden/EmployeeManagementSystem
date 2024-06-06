namespace Employee.Business;

public interface IQuery<TResult, TRequest>
{
    Task<TResult> ExecuteAsync(TRequest request);
}
