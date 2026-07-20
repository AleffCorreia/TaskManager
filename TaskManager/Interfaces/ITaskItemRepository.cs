using System;
using TaskManager.Enums;
using TaskManager.Models;

namespace TaskManager.Interfaces
{
    public interface ITaskItemRepository : IRepository<TaskItem>
    {
        List<TaskItem> GetByStatus(StatusTask statusTask);
        List<TaskItem> GetByPriority(Priority priority);
        List<TaskItem> GetByUserId(int userId);
        List<TaskItem> GetByDateRange(DateTime startDate, DateTime? endDate);

        bool ExistsByUserId(int id);
        
    }
}