using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Task.percestance.Models;

namespace Task.percestance.DataContext
{
   public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
       
      public DbSet<Employee> Employee { get; set; }
       public DbSet<Department> Department { get; set; }
       public DbSet<Country> Country { get; set; }
   
    }
}
