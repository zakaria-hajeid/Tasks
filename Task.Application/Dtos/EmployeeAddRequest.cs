using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task.Application.Dtos
{
  public class EmployeeAddRequest
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public int country { get; set; }
    }
}
