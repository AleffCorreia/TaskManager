using System;
using TaskManager.Enums;
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IUserRepository _userRepository;
        public TaskItemService(ITaskItemRepository taskItemRepository, IUserRepository userRepository)
        {
            _taskItemRepository = taskItemRepository;
            _userRepository = userRepository;
        }

        public void Create(string title, string? description)
        {
            var task = new TaskItem(title, description);

            _taskItemRepository.Add(task);
        }

        public void Update(int id, string title, string? description)
        {
            var task = GetTaskOrThrow(id);

            task.ChangeTitle(title);
            task.ChangeDescription(description);

            _taskItemRepository.Update(task);
        }

        public void Delete(int id)
        {
            var task = GetTaskOrThrow(id);

            _taskItemRepository.Delete(task.Id);
        }

        public void Start(int id)
        {
            var task = GetTaskOrThrow(id);

            task.Start();

            _taskItemRepository.Update(task);

        }

        public void Complete(int id)
        {

            var task = GetTaskOrThrow(id);

            task.Complete();

            _taskItemRepository.Update(task);
        }
        public void Cancel(int id)
        {

            var task = GetTaskOrThrow(id);

            task.Cancel();

            _taskItemRepository.Update(task);
        }

        public void ChangePriority(int id, Priority priority)
        {
            var task = GetTaskOrThrow(id);

            task.ChangePriority(priority);

            _taskItemRepository.Update(task);

        }

        public void AssignToUser(int taskId, int userId)
        {
            var task = GetTaskOrThrow(taskId);
            var user = GetUserOrThrow(userId);
            
            task.AssignToUser(user);

            _taskItemRepository.Update(task);

        }

        public List<TaskItem> GetAll()
        {
            return _taskItemRepository.GetAll();
        }

        public TaskItem? GetById(int id)
        {
            return _taskItemRepository.GetById(id);
        }

        public List<TaskItem> GetByPriority(Priority priority)
        {
            return _taskItemRepository.GetByPriority(priority);
        }

        public List<TaskItem> GetByStatus(StatusTask status)
        {
            return _taskItemRepository.GetByStatus(status);
        }

        public List<TaskItem> GetByUserId(int id)
        {
            return _taskItemRepository.GetByUserId(id);
        }

        private TaskItem GetTaskOrThrow(int id)
        {
            var task = _taskItemRepository.GetById(id);

            if(task == null)
                throw new KeyNotFoundException($"Task with id {id} was not found.");

            return task;
        }
        
        private User GetUserOrThrow(int id)
        {
            var user = _userRepository.GetById(id);
            if(user == null)
                throw new KeyNotFoundException($"Task with id {id} was not found.");

            return user;

        }




    }
}