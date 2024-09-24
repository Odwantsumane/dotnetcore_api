using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class EmployeeMapper
    {
        
        public static EmployeeDto ToEmployeeDto(this Employee employeeDto) 
        {
            return new EmployeeDto{
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Surname = employeeDto.Surname,
                EmployeeNumber = employeeDto.EmployeeNumber,
                HoursWorked = employeeDto.HoursWorked
            };
        }

        public static Employee FromEmployeeDto(this EmployeeDto employeeDto) 
        {
            return new Employee{
                Name = employeeDto.Name,
                Surname = employeeDto.Surname,
                EmployeeNumber = employeeDto.EmployeeNumber,
                HoursWorked = employeeDto.HoursWorked,
                //Days = employeeDto.Days
            };
        }
        public static CreateEmployeeDto ToCreateEmployeeDto(this Employee employeeDto) 
        {
            return new CreateEmployeeDto{
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Surname = employeeDto.Surname,
                EmployeeNumber = employeeDto.EmployeeNumber,
                HoursWorked = employeeDto.HoursWorked,
                //Days = employeeDto.Days
            };
        }

        public static Employee FromCreateEmployeeDto(this CreateEmployeeDto employeeDto) 
        {
            return new Employee{
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Surname = employeeDto.Surname,
                EmployeeNumber = employeeDto.EmployeeNumber,
                HoursWorked = employeeDto.HoursWorked,
                //Days = employeeDto.Days
            };
        }

        public static Employee FromUpdateEmployeeDto(this UpdateEmployeeDto employeeDto, int id) 
        {
            return new Employee{
                Id = id,
                Name = employeeDto.Name,
                Surname = employeeDto.Surname,
                EmployeeNumber = employeeDto.EmployeeNumber,
                HoursWorked = employeeDto.HoursWorked,
                //Days = employeeDto.Days
            };
        }


        public static UpdateEmployeeDto ToUpdateEmployeeDto(this Employee employeeDto) 
        {
            return new UpdateEmployeeDto{
                Name = employeeDto.Name,
                Surname = employeeDto.Surname,
                EmployeeNumber = employeeDto.EmployeeNumber,
                HoursWorked = employeeDto.HoursWorked,
                //Days = employeeDto.Days FromUpdateEmployeeDto(id)
            };
        }
    }
}