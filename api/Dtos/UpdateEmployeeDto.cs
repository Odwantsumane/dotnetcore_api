using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class UpdateEmployeeDto
    {
        public string Name{get;set;} = string.Empty;

        public string Surname{get;set;} = string.Empty;

        public string EmployeeNumber{get;set;} = string.Empty;

        public int HoursWorked{get;set;}
    }
}