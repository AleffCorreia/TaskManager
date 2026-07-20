using System;
using TaskManager.Models;

namespace TaskManager.Services
{
    public interface IUserService
    {

        void Create(string name, string email);
        void Update(int id, string name, string email);
        void Delete(int id);
        List<User> GetAll();
        User? GetById(int id);
        

    }
}