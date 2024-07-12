using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Entities;

namespace WebAPI.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
