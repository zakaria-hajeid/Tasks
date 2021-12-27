using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.percestance.Abstractions
{
    public interface IRepstory<T> where T : class
    {
        Task<List<T>> GetAll();
       Task<T> GetById(int id);
        Task<T> Add(T obj);
        void Update(T obj);
        void Delete(int id);
        Task<bool> save();


    }
}
