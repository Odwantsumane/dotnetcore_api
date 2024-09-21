using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos
{
    public class CreateEmployeeDto
    {
        public string Name{get;set;} = string.Empty;

        public string Surname{get;set;} = string.Empty;

        public string EmployeeNumber{get;set;} = string.Empty;

        public int HoursWorked{get;set;}

        //public List<Days> Days{get;set;} = new List<Days>();
    }
}