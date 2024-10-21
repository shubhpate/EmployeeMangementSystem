using Employee_Management_System.Model;
using Employee_Management_System.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Management_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _empService;

        public EmployeeController(EmployeeService empService)
        {
            _empService = empService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeEntity>>> GetEmployees()
        {
            var employees = await _empService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeEntity>> GetEmployee(int id)
        {
            var employee = await _empService.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<ActionResult> AddEmployee([FromBody] EmployeeEntity employee)
        {
            await _empService.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] EmployeeEntity employee)
        {
            if (id != employee.Id) return BadRequest();
            await _empService.UpdateEmployeeAsync(employee);
            return NoContent();
        }


        [HttpDelete("{ids}")]
        public async Task<ActionResult> DeleteEmployees(string ids)
        {
            var idList = ids.Split(',').Select(int.Parse).ToList();
            await _empService.DeleteEmployeesAsync(idList);
            return NoContent();
        }

    }
}
