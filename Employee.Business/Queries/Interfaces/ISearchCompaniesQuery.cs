using Employee.Business.Models;
using Employee.Business.Queries.Interfaces;

namespace Employee.Business;

public interface ISearchCompaniesQuery : IQuery<IEnumerable<CompanyModel>, string>
{

}
