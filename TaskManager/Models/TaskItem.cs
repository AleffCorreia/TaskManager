using System;
using TaskManager.Enums;

namespace TaskManager.Models
{
    public class TaskItem: BaseEntity
    {
        public string Title { get; private set; }
        public string? Description { get; set; }
        public Priority Priority { get; private set; }
        public DateTime? CompletedAt { get; set; }
        public StatusTask Status { get; private set; }
        public int UserId { get; private set; }
        public User? User { get; private set; }

        public TaskItem(string title, string? description)
        {
            ValidateTitle(title);

            Title = title;
            Status = StatusTask.InProgress;
            Priority = Priority.Medium;
            Description = description;

        }

        private void ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty or whitespace.", nameof(title));
            
        }

        public void Complete()
        {
            ValidadeStatusCompletedOrCanceled();

            Status = StatusTask.Complete;
        }

        public void Cancel()
        {
            ValidadeStatusCompletedOrCanceled();
            Status = StatusTask.Canceled;
        }

        public void ChangePriority(Priority priority)
        {
            ValidadeStatusCompletedOrCanceled();
            Priority = priority;
        }

        public void AssignToUser(User user)
        {
            ValidadeStatusCompletedOrCanceled();
            User = user;
            UserId = user.Id;
        }

        public void Start()
        {
            if (Status != StatusTask.InProgress)
                throw new InvalidOperationException($"This task cannot be started because its status is {Status}.");

            Status = StatusTask.InProgress;
        }

        public void ChangeTitle(string title)
        {
            ValidadeStatusCompletedOrCanceled();
            ValidateTitle(title);
            Title = title;
        }
        public void ChangeDescription(string? description)
        {
            ValidadeStatusCompletedOrCanceled();
            Description = description;
        }
        private void ValidadeStatusCompletedOrCanceled()
        {
            if (Status == StatusTask.Complete || Status == StatusTask.Canceled)
                throw new InvalidOperationException("Cancelled or Complete tasks cannot be change.");
        }

    }
    
}
