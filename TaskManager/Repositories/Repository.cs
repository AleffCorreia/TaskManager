using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public class Repository<T> : IRepository<T> where T: BaseEntity
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
             if(entity == null)
                throw new KeyNotFoundException($"Not result for this id {id}");
            
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();

        }
    }
}