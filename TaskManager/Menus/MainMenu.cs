using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Enums;

namespace TaskManager.Menus
{
    public class MainMenu
    {
        private readonly DashboardMenu _dashboardMenu = new();
     
        public void Show()
        {
            var option = MenuOption.None;
            do
            {
                Console.Clear();
                Console.WriteLine("=========================\n\nTask Manager\n\n=========================");
                Console.WriteLine("1. User");
                Console.WriteLine("2. Task");
                Console.WriteLine("3. Dashboard");
                Console.WriteLine("4. Exit");

                Enum.TryParse<MenuOption>(Console.ReadLine(), out option);

                switch (option)
                {
                    case MenuOption.User:
                        //Users menu here
                        break;
                    case MenuOption.Task:
                        //Tasks option here
                        break;
                    case MenuOption.Dashboard:
                        _dashboardMenu.Show();
                        break;
                    case MenuOption.Exit:
                        Console.WriteLine("Exiting the application...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (option != MenuOption.Exit);
        }
    }
}
