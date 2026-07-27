using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Enums;
using TaskManager.Services;

namespace TaskManager.Menus
{
    public class MainMenu : BaseMenu
    {

        private readonly IUserService _userService;
        private readonly ITaskItemService _taskItemService;
        private readonly DashboardMenu _dashboardMenu = new();
        private readonly UserMenu _userMenu;
        private readonly TaskItemMenu _taskItemMenu;
        public MainMenu(IUserService userService, ITaskItemService taskItemService)
        {
            _userService = userService;
            _taskItemService = taskItemService;

            _userMenu = new UserMenu(userService);
            _taskItemMenu = new TaskItemMenu(taskItemService);
        }
     
        public void Show()
        {
            var option = MenuOption.None;
            do
            {
                
                PrintHeader("Main Menu");
                Console.WriteLine("1.       User");
                Console.WriteLine("2.       Task");
                Console.WriteLine("3.       Dashboard");
                Console.WriteLine("4.       Exit");
                if(!Enum.TryParse<MenuOption>(Console.ReadLine(), out option))
                {
                    InvalidOption();
                    continue;
                }

                switch (option)
                {
                    case MenuOption.User:
                        _userMenu.Show();
                        break;
                    case MenuOption.Task:
                        _taskItemMenu.Show();
                        break;
                    case MenuOption.Dashboard:
                        _dashboardMenu.Show();
                        break;
                    case MenuOption.Exit:
                        Console.WriteLine("Exiting the application...");
                        Pause();
                        break;
                }
            } while (option != MenuOption.Exit);
        }
    }
}
