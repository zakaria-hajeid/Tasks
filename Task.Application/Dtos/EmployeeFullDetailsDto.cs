using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Application.Dtos
{
   public class EmployeeFullDetailsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int DepartmentID { get; set; }
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; }
        public int country { get; set; }
    }
}
