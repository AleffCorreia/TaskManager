using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTables;
using TaskManager.Enums;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Menus
{
    public class TaskItemMenu : BaseMenu
    {
        private readonly ITaskItemService _taskItemService;
        public TaskItemMenu(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        public void Show()
        {
            TaskItemMenuOption option = TaskItemMenuOption.None;

            do
            {
                PrintHeader("Task Menu");
                Console.WriteLine("1.        Create");
                Console.WriteLine("2.        Update");
                Console.WriteLine("3.        Delete");
                Console.WriteLine("4.        GetAll");
                Console.WriteLine("5.        GetById");
                Console.WriteLine("6.        AssignToUser");
                Console.WriteLine("7.        Start");
                Console.WriteLine("8.        Complete");
                Console.WriteLine("9.        Cancel");
                Console.WriteLine("10.       ChangePriority");
                Console.WriteLine("11.       GetByUser");
                Console.WriteLine("12.       Goback");
                if (!Enum.TryParse<TaskItemMenuOption>(Console.ReadLine(), out option))
                {
                    InvalidOption();
                    continue;
                }

                switch (option)
                {
                    case TaskItemMenuOption.Create:
                        Execute(() =>
                        {
                            PrintHeader("Create Task");
                            var title = Read("Enter the title");
                            var description = Read("Enter the description");

                            _taskItemService.Create(title, description);

                            Console.WriteLine("Task created successfully!");
                        });
                        break;
                    case TaskItemMenuOption.Update:
                        Execute(() =>
                        {
                            PrintHeader("Update Task");

                            var id = ReadId();
                            if (id == null)
                                return;

                            var title = Read("Enter the title");
                            var description = Read("Enter the description");

                            _taskItemService.Update(id.Value, title, description);

                            Console.WriteLine("Task updated successfully!");

                        });
                        break;
                    case TaskItemMenuOption.Delete:
                        Execute(() =>
                        {
                            PrintHeader("Delete Task");
                            var id = ReadId();
                            if (id is null)
                                return;

                            _taskItemService.Delete(id.Value);

                            Console.WriteLine("Task deleted successfully!");
                        });
                        break;
                    case TaskItemMenuOption.List:
                        Execute(() =>
                        {
                            PrintHeader("List of tasks");
                            var taskItens = _taskItemService.GetAll();

                            PrintTaskTable(taskItens);
                        });
                        break;
                    case TaskItemMenuOption.GetById:
                        Execute(() =>
                        {
                            PrintHeader("Get task by id");
                            var id = ReadId();
                            if (id is null)
                                return;

                            var task = _taskItemService.GetById(id.Value);
                            List<TaskItem> tasks = [];

                            if (task != null)
                            {
                                tasks.Add(task);
                                PrintTaskTable(tasks);
                                return;
                            }

                            Console.WriteLine("No results...");
                        });
                        break;
                    case TaskItemMenuOption.AssignByUser:
                        Execute(() =>
                        {
                            PrintHeader("Assign task to user");
                            var id = ReadId();
                            var userId = ReadId("Enter the user id");

                            if (id is null || userId is null)
                                return;

                            _taskItemService.AssignToUser(id.Value, userId.Value);

                            Console.WriteLine("Task successfully assigned to the user!");

                        });
                        break;

                    case TaskItemMenuOption.Start:
                        Execute(() =>
                        {
                            PrintHeader("Start Task");
                            var id = ReadId();

                            if (id == null)
                                return;

                            _taskItemService.Start(id.Value);

                            Console.WriteLine("The task has been started");

                        });
                        break;
                    case TaskItemMenuOption.Complete:
                        Execute(() =>
                        {
                            PrintHeader("Complete Task");
                            var id = ReadId();

                            if (id == null)
                                return;

                            _taskItemService.Complete(id.Value);

                            Console.WriteLine("The task has been completed!");
                        });
                        break;
                    case TaskItemMenuOption.Cancel:
                        Execute(() =>
                        {
                            PrintHeader("Cancel Task");
                            var id = ReadId();

                            if (id == null)
                                return;

                            _taskItemService.Cancel(id.Value);

                            Console.WriteLine("The task has been canceled");

                        });
                        break;
                    case TaskItemMenuOption.ChangePriority:
                        Execute(() =>
                        {
                            PrintHeader("Change Priority");
                            var id = ReadId();

                            if (id == null)
                                return;
                            
                            var task = _taskItemService.GetById(id.Value);

                            if(task == null)
                                return;
                            
                            Console.WriteLine($"Title: {task.Title}");
                            Console.WriteLine($"Current Priority: {task.Priority}");

                            Priority priority = task.Priority;

                            Console.WriteLine("1.   Low");
                            Console.WriteLine("2.   Medium");
                            Console.WriteLine("3.   High");
                            bool result = Enum.TryParse<Priority>(Read("4.  Urgent"), out priority);

                            if(!result)
                                return;
                            
                            _taskItemService.ChangePriority(id.Value, priority);

                            Console.WriteLine("Priority has been changed!");

                        });
                        break;
                        case TaskItemMenuOption.GetByUser:
                            Execute(() =>
                            {
                                PrintHeader("Get By User");
                                var userId = ReadId("Enter user id");

                                if(userId == null)
                                    return;

                                List<TaskItem> tasks = _taskItemService.GetByUserId(userId.Value);

                                if(tasks.Count == 0)
                                    return;
                                    
                                PrintTaskTable(tasks);

                            });
                            break;




                }

            } while (option != TaskItemMenuOption.Goback);
        }

        private void PrintTaskTable(List<TaskItem> taskItens)
        {
            var table = new ConsoleTable("Id", "Title", "Description", "Priority", "Status", "Start Date", "Completed Date", "User");



            foreach (var task in taskItens)
            {
                table.AddRow(task.Id, task.Title, task.Description, task.Priority, task.Status,
                    task.CreatedAt, task.CompletedAt,
                    task.User is null ? "Not assigne" : task.User.Name);
            }

            table.Write();

        }

    }
}