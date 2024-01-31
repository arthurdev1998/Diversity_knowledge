using Microsoft.EntityFrameworkCore;
using PaginationAndImage.Models;

namespace PaginationAndImage.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Employee> Employees { get; set; }
}