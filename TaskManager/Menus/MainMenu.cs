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
        private readonly DashboardMenu _dashboardMenu;
        private readonly UserMenu _userMenu;
        private readonly TaskItemMenu _taskItemMenu;
        public MainMenu(IUserService userService, ITaskItemService taskItemService)
        {
            _userService = userService;
            _taskItemService = taskItemService;

            _userMenu = new UserMenu(userService);
            _taskItemMenu = new TaskItemMenu(taskItemService);

            _dashboardMenu = new DashboardMenu(taskItemService, userService);
        }

        public void Show()
        {
            var option = MenuOption.None;
            do
            {
                Console.Clear();
                _dashboardMenu.Show();

                PrintHeader("Main Menu");
                Console.WriteLine("1.       User");
                Console.WriteLine("2.       Task");
                Console.WriteLine("3.       Exit");
                if (!Enum.TryParse<MenuOption>(Console.ReadLine(), out option))
                {
                    InvalidOption();
                    continue;
                }

                switch (option)
                {
                    case MenuOption.User:
                        Console.Clear();
                        _userMenu.Show();
                        break;
                    case MenuOption.Task:
                        Console.Clear();
                        _taskItemMenu.Show();
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
