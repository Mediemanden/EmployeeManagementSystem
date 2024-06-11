using Employee.Business.Models;

namespace Employee.Business;

public static class CompanyValidator
{

    public static void ValidateCompanyExists(CompanyModel? company)
    {
        if (company == null)
        {
            throw ExceptionHandler.GetEmsExceptionForCode(ExceptionCodes.CompanyNotFound__1501);
        }
    }

}
