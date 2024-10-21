using Employee_Management_System.Model;
using Microsoft.EntityFrameworkCore;
using Employee_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System.Repository
{
    public class EmployeeRepository
    {
        private readonly EmployeeDBContext _context;

        public EmployeeRepository(EmployeeDBContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeEntity>> GetAllEmployeesAsync()
        {
            return await _context.employeedetails.ToListAsync();
        }

        public async Task<EmployeeEntity> GetEmployeeByIdAsync(int id)
        {
            return await _context.employeedetails.FindAsync(id);
        }

        public async Task AddEmployeeAsync(EmployeeEntity employee)
        {
            await _context.employeedetails.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(EmployeeEntity employee)
        {
            _context.employeedetails.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeesAsync(List<int> ids)
        {
            var employees = await _context.employeedetails
                .Where(e => ids.Contains(e.Id)) // Use a query to find employees by IDs
                .ToListAsync();

            if (employees.Any())
            {
                _context.employeedetails.RemoveRange(employees); // Remove all employees in the list
                await _context.SaveChangesAsync();
            }
        }

    }
}
