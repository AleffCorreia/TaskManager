using System;
using TaskManager.Enums;

namespace TaskManager.Models
{
    public class Task: BaseEntity
    {
        public string Title { get; private set; }
        public string? Description { get; set; }
        public Priority Priority { get; private set; }
        public DateTime? CompletedDate { get; set; }
        public StatusTaks Status { get; private set; }
        public int UserId { get; private set; }
        public User? User { get; private set; }

        public Task(string title, string? description)
        {
            ValidateTitle(title);

            Title = title;
            Status = StatusTaks.InProgress;
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

            Status = StatusTaks.Complete;
        }

        public void Cancel()
        {
            ValidadeStatusCompletedOrCanceled();
            Status = StatusTaks.Canceled;
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
            if (Status != StatusTaks.InProgress)
                throw new InvalidOperationException($"This task cannot be started because its status is {Status}.");

            Status = StatusTaks.InProgress;
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
            if (Status == StatusTaks.Complete || Status == StatusTaks.Canceled)
                throw new InvalidOperationException("Cancelled or Complete tasks cannot be change.");
        }

    }
    
}
