using Employee_Management_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.Data
{
    public class EmployeeDBContext :DbContext
    {
        public EmployeeDBContext(DbContextOptions opetions) : base(opetions)
        {
            
        }
        public DbSet<EmployeeEntity> employeedetails { get; set; }
        public DbSet<LoginEntity> logins { get; set; }
    }
}
