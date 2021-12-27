using System;
using System.Collections.Generic;
using System.Text;
using Task.percestance.Abstractions;
using Task.percestance.Models;

namespace Task.percestance
{
   public class CountryRepository : GenericRepository<Country>, ICountry
    {
        public CountryRepository(DataContext.DataContext context) : base(context)
        {

        }
    }
}
