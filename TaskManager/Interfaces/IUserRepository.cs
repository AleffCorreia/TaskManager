using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User? GetByEmail(string email);

        bool ExistsByEmail(string email);
    }
}