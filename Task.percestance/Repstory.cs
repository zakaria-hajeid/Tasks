using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.percestance.Abstractions;
using Task.percestance.DataContext;

namespace Task.percestance
{
    public class GenericRepository<T> : IRepstory<T> where T : class
    {
        private readonly DataContext.DataContext _context;
        private DbSet<T> table;
        public GenericRepository(DataContext.DataContext context)
        {
            _context = context;

            table = _context.Set<T>();
        }
     
        public async  Task<List<T>> GetAll()
        {
            return await table.ToListAsync();
        }
        public async Task<T>  GetById(int id)
        {
            return await table.FindAsync(id);
        }
        public async Task<T> Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            try
            {


                await _context.AddAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }



        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
      

        public async Task<bool> save()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
