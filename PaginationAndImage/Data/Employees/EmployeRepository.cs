using Microsoft.EntityFrameworkCore;
using PaginationAndImage.Data.Context;
using PaginationAndImage.Models;

namespace PaginationAndImage.Data.Employees;

public class EmployeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee>> Employees()
    {
        return await _context.Employees.ToListAsync();
    }
}