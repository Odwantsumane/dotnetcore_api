using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Employee
    {
        public int Id{get;set;}

        public string Name{get;set;} = string.Empty;

        public string Surname{get;set;} = string.Empty;

        public string EmployeeNumber{get;set;} = string.Empty;

        public int HoursWorked{get;set;}

        public List<Days> Days{get;set;} = new List<Days>(); 


    }
}