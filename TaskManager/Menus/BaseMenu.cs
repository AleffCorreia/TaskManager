using System;
using TaskManager.Services;

namespace TaskManager.Menus
{
    public abstract class BaseMenu
    {
        protected void PrintHeader(string menuTitle)
        {
            Console.Clear();
            Console.WriteLine("=====================================\n");
            Console.WriteLine($"TaskManager - {menuTitle}");
            Console.WriteLine("\n=====================================\n");
        }

        protected string? Read(string optionText)
        {
            Console.WriteLine(optionText);
            return Console.ReadLine();
        }

        protected void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        protected void InvalidOption()
        {
            Console.WriteLine("Invalid option!");
            Pause();
        }

        protected int? ReadId(string? message = "Enter the ID:" )
        {
            if (!int.TryParse(Read(message), out var id))
            {
                Console.WriteLine("Invalid ID.");
                return null;
            }

            return id;
        }

        protected void Execute(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally{
                Pause();
            }
        }




    }
}