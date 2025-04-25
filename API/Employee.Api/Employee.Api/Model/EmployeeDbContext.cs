using Microsoft.EntityFrameworkCore;

namespace Employee.Api.Model
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options): base(options) 
        { 
        
        }

        public DbSet<EmployeeData> EmployeeData { get; set; }

        public DbSet<DropDownListItems> DropDownListItems { get; set; }
    }
}
