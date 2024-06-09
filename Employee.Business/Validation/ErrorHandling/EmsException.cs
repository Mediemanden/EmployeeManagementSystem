namespace Employee.Business;

public class EmsException : Exception
{
    public ExceptionCodes Code { get; }

    public EmsException(ExceptionCodes code, string message) : base(message)
    {
        Code = code;
    }

    public EmsException(ExceptionCodes code, string message, Exception innerException) : base(message, innerException)
    {
        Code = code;
    }
}
