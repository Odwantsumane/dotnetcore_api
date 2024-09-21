using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class Employees : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public Employees(ApplicationDBContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll() 
        {
            var employees = _context.Employee.ToList();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id) 
        {
            var employee = _context.Employee.Find(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeDto employee)
        {
            var EmployeeModel = employee.FromEmployeeDto();
            _context.Add(EmployeeModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = EmployeeModel.Id }, EmployeeModel.ToEmployeeDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateEmployee([FromRoute] int id, [FromBody] CreateEmployeeDto employee) 
        {
            var EmployeeModel = _context.Employee.FirstOrDefault( x => x.Id == id);

            if(EmployeeModel == null) return NotFound();

            EmployeeModel.Name = employee.Name;
            EmployeeModel.EmployeeNumber = employee.EmployeeNumber;
            EmployeeModel.Surname = employee.Surname;
            EmployeeModel.HoursWorked = employee.HoursWorked;

            _context.SaveChanges();

            return Ok(EmployeeModel.ToEmployeeDto());
        }
    }
}