using Employee.Business.Models;

namespace Employee.Business.Queries.Interfaces;

public interface IGetCompanyQuery : IQuery<CompanyModel, Guid>
{

}
