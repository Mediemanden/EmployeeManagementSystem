using System.ComponentModel;
using System.Reflection;

namespace Employee.Business;

public class ExceptionHandler
{
    public static EmsException GetEmsExceptionForCode(ExceptionCodes code)
    {
        string errorMessage = GetDescriptionForCode(code);

        return new EmsException(code, errorMessage);
    }

    public static string GetDescriptionForCode(ExceptionCodes code)
    {
        FieldInfo? field = code.GetType().GetField(code.ToString());
        DescriptionAttribute? attribute = (DescriptionAttribute?)field?.GetCustomAttribute(typeof(DescriptionAttribute));

        return attribute?.Description ?? "No description available";
    }
}
