using System;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Enums;
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    internal class TaskItemRepository : Repository<TaskItem>, ITaskItemRepository
    {

        private DbSet<TaskItem> TaskItems => _context.Set<TaskItem>();

        public TaskItemRepository(AppDbContext context) : base(context)
        {
        }

        public List<TaskItem> GetByStatus(StatusTask status)
        {
            return _context
                        .TaskItems
                        .Where(t => t.Status == status)
                        .ToList();
        }

        public List<TaskItem> GetByPriority(Priority priority)
        {
            return _context
                        .TaskItems
                        .Where(t => t.Priority == priority)
                        .ToList();
        }

        public List<TaskItem> GetByUserId(int userId)
        {
            return _context
                        .TaskItems
                        .Where(t => t.UserId == userId)
                        .ToList();
        }

        public bool ExistsByUserId(int userId)
        {
            return _context
                        .TaskItems
                        .Any(t => t.UserId == userId);
        }

        public override List<TaskItem> GetAll()
        {
            return 
                _context
                .TaskItems
                .Include(t => t.User)
                .ToList();
        }

        public override TaskItem? GetById(int id)
        {
            return 
                _context
                .TaskItems
                .Include(t => t.User)
                .SingleOrDefault(t => t.Id == id);
        }

       
    }
}
