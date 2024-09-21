using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;

namespace api.Mappers
{
    public static class CreateEmployeeMapper
    {
        public static CreateEmployeeDto CreateEmployeeDto(this CreateEmployeeDto createEmployeeDto)
        {
            return new CreateEmployeeDto  
            {
                Name = createEmployeeDto.Name,
                Surname = createEmployeeDto.Surname,
                EmployeeNumber = createEmployeeDto.EmployeeNumber,
                HoursWorked = createEmployeeDto.HoursWorked,
                // Days = createEmployeeDto.Days
            };
        }
    }
}