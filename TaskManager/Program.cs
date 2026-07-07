internal class Program
{
    private static void Main(string[] args)
    {
        dashboard();
        bool menu = true;
        do
        {
            Console.Clear();
            var option = "";
            Console.WriteLine("=========================\n\nTask Manager\n\n=========================");
            Console.WriteLine("Press: 1 to User Services\n" +
                "Press: 2 to Task Services\n" +
                "Press: 3 to Dashboard\n" +
                "Press: 0 to exit program");
            option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    // Add task
                    
                    break;
                case "2":
                    // View tasks
                  
                    break;
                case "3":
                    Console.Clear();
                    dashboard();
                    break;
                case "0":
                    Console.WriteLine("The program will exit, are you sure? (y/n)");
                    var exitOption = Console.ReadLine();
                    if (exitOption == "y")
                    {
                        menu = false;
                        break;
                    }
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid option, try again");
                    break;
            }

        } while (menu);


        static void dashboard()
        {

            bool skipDashboard = true;

            do
            {
                Console.WriteLine("=========================\n\nTask Manager\n\n=========================");

                Console.WriteLine("Numbers of users:");
                Console.WriteLine("Total tasks:");
                Console.WriteLine("Pending:");
                Console.WriteLine("In progress:");
                Console.WriteLine("Conplete:");
                Console.WriteLine("Canceled:");

                Console.WriteLine("\n\nPress any key to return to the menu...");

                bool.TryParse(Console.ReadLine(), out skipDashboard);
            } while (skipDashboard);
        }
    }
}