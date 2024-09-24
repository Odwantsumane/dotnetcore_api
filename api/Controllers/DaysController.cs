using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/api/Days")]
    [ApiController]
    public class DaysController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IEmployeeRepository _empRepo;
        public DaysController(ApplicationDBContext applicationDBContext, IEmployeeRepository empRepo)
        {
            _context = applicationDBContext;
            _empRepo = empRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Days.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var Day = _context.Days.FirstOrDefault(d => d.Id == id);

            if(Day == null) return NotFound();

            return Ok(Day);
        }

        [HttpPost] 
        [Route("{employeeId}")]
        public async Task<IActionResult> CreateDay([FromBody] Days day, [FromRoute] int employeeId)
        {

            var employee = await _empRepo.GetEmployeeAsync(employeeId);

            if(employee == null) return BadRequest("Employee does not exist");

            _context.Add(day);

            _context.SaveChanges();

            return Ok(day);
        }
    }
}