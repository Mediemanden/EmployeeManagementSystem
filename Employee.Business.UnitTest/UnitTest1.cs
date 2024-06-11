using System;
using Employee.Business.Commands;
using Employee.Business.Models;
using Employee.DataAccess;
using Employee.DataAccess.Storage.Interfaces;
using NSubstitute;

namespace Employee.Business.UnitTest;

public class CreateEmployeeTests
{
    private IEmployeeStorageWithMemoryCache _employeeStorageMock;
    private ICompanyService _companyServiceMock;
    [SetUp]
    public void Setup()
    {
        _employeeStorageMock = Substitute.For<IEmployeeStorageWithMemoryCache>();
        _companyServiceMock = Substitute.For<ICompanyService>();
    }

    [Test]
    public void CreateNewEmployee_WithEmptyName_ExpectError1401()
    {
        // Testdata 
        EmployeeModel employee = new()
        {
            Id = Guid.NewGuid(),
            FullName = "", // Empty name
            DateOfBirth = DateTime.Now.AddYears(-20),
            Salary = 1000,
            Department = "IT"
        };

        // Setup
        var command = new CreateEmployeeCommand(_employeeStorageMock, _companyServiceMock);

        // Act and Assert
        EmsException ex = Assert.ThrowsAsync<EmsException>(() => command.ExecuteAsync(employee));

        Assert.That(ex.Code, Is.EqualTo(ExceptionCodes.EmployeeNameRequired__1401));
    }

    [Test]
    public void CreateNewEmployee_EmployeeTooYoung_ExpectError1402()
    {
        // Testdata 
        EmployeeModel employee = new()
        {
            Id = Guid.NewGuid(),
            FullName = "John Doe",
            DateOfBirth = DateTime.Now.AddYears(-1), // Too young
            Salary = 1000,
            Department = "IT",
        };

        // Setup
        var command = new CreateEmployeeCommand(_employeeStorageMock, _companyServiceMock);

        // Act and Assert
        EmsException ex = Assert.ThrowsAsync<EmsException>(() => command.ExecuteAsync(employee));

        Assert.That(ex.Code, Is.EqualTo(ExceptionCodes.EmployeeAgeUnder16__1402));
    }
}