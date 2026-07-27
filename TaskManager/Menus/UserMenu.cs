using System;
using TaskManager.Services;
using TaskManager.Enums;
using TaskManager.Models;
using ConsoleTables;


namespace TaskManager.Menus
{
    public class UserMenu : BaseMenu
    {
        private readonly IUserService _userService;

        public UserMenu(IUserService userService)
        {
            _userService = userService;
        }

        public void Show()
        {
            var option = UserMenuOption.None;

            do
            {
                PrintHeader("User Menu");
                Console.WriteLine("1.       Create");
                Console.WriteLine("2.       Update");
                Console.WriteLine("3.       List");
                Console.WriteLine("4.       Delete");
                Console.WriteLine("5.       GetById");
                Console.WriteLine("6.       Goback");
                if (!Enum.TryParse<UserMenuOption>(Console.ReadLine(), out option))
                {
                    InvalidOption();
                    continue;
                }

                switch (option)
                {
                    case UserMenuOption.Create:
                        Create();
                        break;
                    case UserMenuOption.Update:
                        Update();
                        break;
                    case UserMenuOption.List:
                        GetAll();
                        break;
                    case UserMenuOption.Delete:
                        Delete();
                        break;
                    case UserMenuOption.FindById:
                        GetById();
                        break;
                    case UserMenuOption.GoBack:
                        option = UserMenuOption.GoBack;
                        break;
                }
            } while (option != UserMenuOption.GoBack);
        }

        private void Create()
        {
            Execute(() =>
            {
                string? name;
                string? email;
                PrintHeader("Create User");

                name = Read("Enter the name.");
                email = Read("Enter the e-mail");

                _userService.Create(name, email);

                Console.WriteLine("Sucess!");
            });

        }

        private void Update()
        {

            Execute(() =>
            {
                PrintHeader("Update user");
                var id = ReadId();
                if(id is null)
                    return;

                var name = Read("Enter the new name");
                var email = Read("Enter the new e-mail");

                _userService.Update(id.Value, name, email);

                Console.WriteLine("Success!");
            });
        }

        private void Delete()
        {
           Execute(() =>
           {
               PrintHeader("Delete user");
                int? id = ReadId();

                if(id is null)
                    return;

                _userService.Delete(id.Value);

                Console.WriteLine("Success");
           });
        }

        private void GetAll()
        {
           Execute(() =>
           {
                PrintHeader("List of users");
                List<User> users = _userService.GetAll();

                if (users.Count == 0)
                {
                    Console.WriteLine("Users not found.");
                    return;
                }

               PrintUserTable(users);
               

           });

        }

        private void GetById()
        {
            Execute(() =>
            {
                 PrintHeader("User Info");
                int? id = ReadId();

                if (id is null)
                    return;

                var user = _userService.GetById(id.Value);
                if (user is null)
                {
                    Console.WriteLine($"No records for id: {id}");
                    return;
                }
                PrintUser(user);
            });
        }

        private void PrintUser(User user)
        {

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Id: {user.Id}");
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
        }

        private void PrintUserTable(List<User> users)
        {
            var table = new ConsoleTable("Id", "Name", "Email");

            foreach(var user in users)
            {
                table.AddRow(user.Id, user.Name, user.Email);
            }

            table.Write();

        }


    }
}