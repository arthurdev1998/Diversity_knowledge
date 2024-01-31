using PaginationAndImage.Models;

namespace PaginationAndImage.Data.Employees;

public interface IEmployeeRepository
{
    public Task<IEnumerable<Employee>> Employees();
}