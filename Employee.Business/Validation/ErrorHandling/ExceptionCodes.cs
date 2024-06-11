using System.ComponentModel;

namespace Employee.Business;

public enum ExceptionCodes
{
    [Description("An error occurred while processing the request")]
    GeneralError__1000 = 1000,
    [Description("Employee name is required")]
    EmployeeNameRequired__1401 = 1401,
    [Description("Employee age must be at least 16. No child labor allowed!")]
    EmployeeAgeUnder16__1402 = 1402,
    [Description("Employee email is invalid")]
    EmployeeEmailInvalid__1403 = 1403,
    [Description("Employee not found")]
    EmployeeNotFound__1404 = 1404,
    [Description("Employee salary must be greater than 0. No one works for free!")]
    EmployeeSalaryInvalid__1405 = 1405,
    [Description("Company with given ID not found")]
    CompanyNotFound__1501 = 1501,
}
