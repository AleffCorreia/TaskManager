using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Menus;
using TaskManager.Models;
using TaskManager.Repositories;
using TaskManager.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("Data Source=TaskManager.db")
            .Options;
        
        var context = new AppDbContext(options);

        var userRepository = new UserRepository(context);
        var taskItemRepository = new TaskItemRepository(context);
        
        var userService = new UserService(userRepository, taskItemRepository);
        var taskService = new TaskItemService(taskItemRepository, userRepository);

        MainMenu mainMenu = new(userService, taskService);
        mainMenu.Show();

    }
}