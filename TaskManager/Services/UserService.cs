using System;
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITaskItemRepository _taskRepository;

        public UserService(IUserRepository userRepository, ITaskItemRepository taskItemRepository)
        {
            _userRepository = userRepository;
            _taskRepository = taskItemRepository;
        }

        public void Create(string name, string email)
        {
            if(_userRepository.ExistsByEmail(email))
                throw new ArgumentException("This e-mail already exists.");

            var user = new User(name, email);
            _userRepository.Add(user); 
        }

        public void Update(int id, string name, string email)
        {
            
            var user = _userRepository.GetById(id);
            if(user == null)
                throw new KeyNotFoundException($"No records for id: {id}");

            if(user.Email != email)
            {
                
                var existUser = _userRepository.GetByEmail(email);
                if(existUser != null && user.Id != existUser.Id)
                    throw new ArgumentException("This e-mail already exists");
            }
            
            user.ChangeName(name);
            user.ChangeEmail(email);

            _userRepository.Update(user);
                        
        }
        
        public void Delete(int id)
        {
            var user = _userRepository.GetById(id);
            if(user == null)
                throw new KeyNotFoundException($"No records for id: {id}");

            if(_taskRepository.ExistsByUserId(id))
                throw new InvalidOperationException("Cannot delete a user that has tasks.");
            
            _userRepository.Delete(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            var user =  _userRepository.GetById(id);
            if(user == null)
                throw new KeyNotFoundException($"No record for id {id}");

            return user;
        }

        
    }
}