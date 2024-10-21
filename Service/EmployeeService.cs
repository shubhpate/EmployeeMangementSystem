using Employee_Management_System.Model;
using Employee_Management_System.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Management_System.Service
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _repository;

        public EmployeeService(EmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmployeeEntity>> GetAllEmployeesAsync()
        {
            var employees=await _repository.GetAllEmployeesAsync();
            return employees.Select(e => new EmployeeEntity
            {
                Id = e.Id,
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                Email = e.Email,
                Phone = e.Phone,
                Position = e.Position,
                Salary = e.Salary,
            }).ToList();
            
        }

        public async Task<EmployeeEntity> GetEmployeeByIdAsync(int id)
        {
            return await _repository.GetEmployeeByIdAsync(id);
        }

        public async Task AddEmployeeAsync(EmployeeEntity employee)
        {
            await _repository.AddEmployeeAsync(employee);
        }

        public async Task UpdateEmployeeAsync(EmployeeEntity employee)
        {
            await _repository.UpdateEmployeeAsync(employee);
        }


        public async Task DeleteEmployeesAsync(List<int> ids)
        {
            await _repository.DeleteEmployeesAsync(ids);
        }

    }
}
