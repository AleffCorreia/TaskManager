using System;
using System.Net.Mail;


namespace TaskManager.Models
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public List<TaskItem>? Tasks { get; } = [];

        public User(string name, string email)
        {
            ValidateName(name);
            ValidateEmail(email);

            Name = name;
            Email = email;
        }

        public void ChangeName(string name)
        {
            if(Name == name)
                return;

            ValidateName(name);

            Name = name;
        }

        public void ChangeEmail(string email)
        {
            if (Email == email)
                return;
            ValidateEmail(email);
            Email = email;
        }

        private static void ValidateName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.",nameof(name));

        }

        private static void ValidateEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty.",nameof(email));

            if(!MailAddress.TryCreate(email, out var _))
                throw new ArgumentException("Email is not valid.",nameof(email));
        }
    }
}
