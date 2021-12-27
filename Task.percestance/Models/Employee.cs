using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task.percestance.Models
{
    public class Employee
    {
       
        public int Id { get; set; }
        public string FullName { get; set; }
        public int DepartmentID { get; set; }
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; }
        public int country { get; set; }
        public Department Department { get; set; }
        public Country Country { get; set; }

    }
}
