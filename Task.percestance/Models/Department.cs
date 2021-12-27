using System;
using System.Collections.Generic;
using System.Text;

namespace Task.percestance.Models
{
   public class Department
    {
        public int Id { get; set; }
        public string name { get; set; }
        public ICollection<Employee> Employee { get; set; }

    }
}
