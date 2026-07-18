using System;

namespace TaskManager.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(int Id);

        List<T> GetAll();

        T? GetById(int id);
    }
}