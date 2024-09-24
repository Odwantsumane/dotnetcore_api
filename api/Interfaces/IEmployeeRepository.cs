using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> AllEmployeesAsync();
        Task<Employee?> GetEmployeeAsync(int id);
        Task<Employee?> UpdateEmployeeAsync(int id, Employee employee);
        Task<Employee?> DeleteEmployeeAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee employee);
    }
}