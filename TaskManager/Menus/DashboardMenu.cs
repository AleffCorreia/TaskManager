using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Services;
using TaskManager.Enums;

namespace TaskManager.Menus
{
    public class DashboardMenu : BaseMenu
    {

        private readonly ITaskItemService _taskItemService;
        private readonly IUserService _userService;

        public DashboardMenu(ITaskItemService taskItemService, IUserService userService)
        {
            _taskItemService = taskItemService;
            _userService = userService;
        }

        public void Show()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("Dashbaord");
            Console.WriteLine("=====================================");
            Console.WriteLine($"User..............{GetCountUsers()}");
            Console.WriteLine($"Tasks.............{GetCountTasks()}");
            Console.WriteLine($"Pedding...........{GetCountTasksByStatus(StatusTask.Pedding)}");
            Console.WriteLine($"In Progress.......{GetCountTasksByStatus(StatusTask.InProgress)}");
            Console.WriteLine($"Complete..........{GetCountTasksByStatus(StatusTask.Complete)}");
            Console.WriteLine($"Canceled..........{GetCountTasksByStatus(StatusTask.Canceled)}");

        }

        private int GetCountUsers()
        {
            return
                _userService
                .GetAll()
                .Count;
        }

        private int GetCountTasks()
        {
            return
                _taskItemService
                .GetAll()
                .Count;
        }

        private int GetCountTasksByStatus(StatusTask status)
        {
            return
                _taskItemService
                .GetByStatus(status)
                .Count;
        }

        


    }
}
