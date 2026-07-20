using System;
using TaskManager.Enums;
using TaskManager.Models;

namespace TaskManager.Services
{
    public interface ITaskItemService
    {
        void Create(string title, string? description);
        void Update(int id, string title, string? description);
        void Delete(int id);
        void Start(int id);
        void Complete(int id);
        void Cancel(int id);
        void ChangePriority(int id, Priority priority);
        void AssignToUser(int taskId, int userId);
        List<TaskItem> GetByStatus(StatusTask statusTask);
        List<TaskItem> GetByPriority(Priority priority);
        List<TaskItem> GetAll();
        TaskItem? GetById(int id);
        List<TaskItem> GetByUserId(int userId);
        


    }
}