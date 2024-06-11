namespace Employee.Business.Models;

public class CompanyModel
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Address { get; init; }
    public Guid? ParentCompanyId { get; init; }
}
