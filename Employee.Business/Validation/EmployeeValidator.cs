using Employee.Business.Models;

namespace Employee.Business;

public static class EmployeeValidator
{
    public static void ValidateEmployee(EmployeeModel employee)
    {
        if (string.IsNullOrWhiteSpace(employee.FullName))
        {
            throw ExceptionHandler.GetEmsExceptionForCode(ExceptionCodes.EmployeeNameRequired__1401);
        }

        if (employee.Age < 16)
        {
            throw ExceptionHandler.GetEmsExceptionForCode(ExceptionCodes.EmployeeAgeUnder16__1402);
        }

        if (employee.Salary <= 0)
        {
            throw ExceptionHandler.GetEmsExceptionForCode(ExceptionCodes.EmployeeSalaryInvalid__1405);
        }
    }
}
