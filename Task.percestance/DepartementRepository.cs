using System;
using System.Collections.Generic;
using System.Text;
using Task.percestance.Abstractions;
using Task.percestance.Models;

namespace Task.percestance
{
   public class DepartementRepository : GenericRepository<Department>, IDepartement
    {
        public DepartementRepository(DataContext.DataContext context) : base(context)
        {
                
        }
    }
}
