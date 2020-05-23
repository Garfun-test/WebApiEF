using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEF.DAL.Models;

namespace WebApiEF.DAL.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int Id);
        Task<T> GetById2(int Id, int id2);
        Task Insert(T obj);
        void Update(int id, T entity);
        void Delete(int id);
    }
}
