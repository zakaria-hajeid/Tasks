using System;
using System.Collections.Generic;
using System.Text;
using Task.percestance.Abstractions;
using Task.percestance.Models;
using Task.percestance.DataContext;

namespace Task.percestance
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployee
    {
        public EmployeeRepository(DataContext.DataContext context) : base(context)
        {

        }
    }
}
