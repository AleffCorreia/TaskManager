using System;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
      
        private DbSet<User> Users => _context.Set<User>();

        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public User? GetByEmail(string email)
        {
            return _context
                        .Users
                        .SingleOrDefault(u => u.Email == email);

        }

        public bool ExistsByEmail(string email)
        {
            return _context
                        .Users
                        .Any(u => u.Email == email);
        }

    }
}
