using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiEF;
using WebApiEF.DAL.Interface;
using WebApiEF.DAL.Models;

namespace WebApiEF.DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected EFTestContext _context;

        private DbSet<T> dbSet;

        public GenericRepository(EFTestContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.AsNoTracking()
                              .ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> GetById2(int id, int id2)
        {
            return await dbSet.FindAsync(id,id2);
        }

        public async Task Insert(T obj)
        {
            await dbSet.AddAsync(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            T entityToDelete = dbSet.Find(id);
            dbSet.Remove(entityToDelete);
            _context.SaveChanges();
        }

        public void Update(int id, T obj)
        {
            dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}