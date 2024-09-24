using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class Employees : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IEmployeeRepository _empRepo;
        public Employees(ApplicationDBContext context, IEmployeeRepository empRepo) {
            _context = context;
            _empRepo = empRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var employees = await _empRepo.AllEmployeesAsync();

            return Ok(employees);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            var employee = await _empRepo.GetEmployeeAsync(id);

            if (employee == null) return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] CreateEmployeeDto employee)
        {
            var EmployeeModel = await _empRepo.AddEmployeeAsync(employee.FromCreateEmployeeDto());

            return CreatedAtAction(nameof(GetById), new { id = EmployeeModel.Id }, EmployeeModel.ToEmployeeDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] UpdateEmployeeDto employee) 
        {
            var EmployeeModel = await _empRepo.UpdateEmployeeAsync(id, employee.FromUpdateEmployeeDto(id));

            if(EmployeeModel == null) return NotFound("Employee does not exist"); 

            return Ok(EmployeeModel.ToEmployeeDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id) 
        {
            var EmployeeModel = await _empRepo.DeleteEmployeeAsync(id);

            if(EmployeeModel == null) return NotFound("Employee does not exist"); 

            return Ok(EmployeeModel.ToEmployeeDto());
        }
    }
}