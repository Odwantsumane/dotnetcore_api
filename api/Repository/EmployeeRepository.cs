using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBContext _context;
        public EmployeeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<List<Employee>> AllEmployeesAsync()
        {
            return await _context.Employee.Include(c => c.Days).ToListAsync();
        }

        public async Task<Employee?> DeleteEmployeeAsync(int id)
        {
            var employeeModel = await _context.Employee.FirstOrDefaultAsync(e => e.Id == id);

            if(employeeModel == null) return null;

            _context.Remove(employeeModel);
            await _context.SaveChangesAsync();

            return employeeModel;
        }

        public async Task<Employee?> GetEmployeeAsync(int id)
        {
            var employeeModel = await _context.Employee.FirstOrDefaultAsync(e => e.Id == id);

            if(employeeModel == null) return null;

            return employeeModel;
        }

        public async Task<Employee?> UpdateEmployeeAsync(int id, Employee employee)
        {
            var employeeModel = await _context.Employee.FirstOrDefaultAsync(e => e.Id == id);

            if(employeeModel == null) return null;

            employeeModel.Name = employee.Name;
            employeeModel.Surname = employee.Surname;
            employeeModel.EmployeeNumber = employee.EmployeeNumber;
            employeeModel.HoursWorked = employee.HoursWorked;

            await _context.SaveChangesAsync();

            return employeeModel;
        }
    }
}