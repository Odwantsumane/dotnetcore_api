using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Days
    {
        public int Id{get;set;}
        public DateTime Date{get;set;} = DateTime.Now;

        public string DayName{get;set;} = string.Empty;

        public int EmployeeId{get;set;}

        // public Employee? Employee{get;set;}
    }
}