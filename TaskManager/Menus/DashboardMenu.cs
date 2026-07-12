using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Menus
{
    public class DashboardMenu
    {

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=========================\nTask Manager - Dashboard\n=========================");
            Console.WriteLine("User...............0");
            Console.WriteLine("Tasks..............0");
            Console.WriteLine("Pedding............0");
            Console.WriteLine("In Progress........0");
            Console.WriteLine("Complete...........0");
            Console.WriteLine("Canceled...........0");
            Console.ReadKey();
        }
    }
}
