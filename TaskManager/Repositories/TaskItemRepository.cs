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
                        .Set<TaskItem>()
                        .Where(t => t.Priority == priority)
                        .ToList();
        }

        public List<TaskItem> GetByUserId(int userId)
        {
            return _context
                        .Set<TaskItem>()
                        .Where(t => t.UserId == userId)
                        .ToList();
        }

        public List<TaskItem> GetByDateRange(DateTime startDate, DateTime? endDate)
        {
            return _context
                        .Set<TaskItem>()
                        .Where(t => 
                            t.CompletedAt.HasValue && 
                            t.CompletedAt >= startDate && 
                            t.CompletedAt <= endDate)
                        .ToList();
        }
    }
}
