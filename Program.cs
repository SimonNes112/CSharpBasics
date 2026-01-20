using System;

namespace MenuApp
{
    class Program
    {
        public record User(string FirstName, string LastName);
        private static List<User> Users = new List<User>();

        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add a user");
            Console.WriteLine("2) Remove a user");
            Console.WriteLine("3) Exit");
            Console.WriteLine("4) View users");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddUser();
                    Console.ReadKey();
                    return true;
                case "2":
                    RemoveUser();
                    Console.ReadKey();
                    return true;
                case "3":
                    return false;
                case "4":
                    ShowAllUsers();
                    Console.ReadKey();
                    return true;
                default:
                    return true;
            }

        }

        private static void AddUser()
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Users.Add(new User(firstName, lastName));
            Console.WriteLine("User added successfully!");
            Console.WriteLine("Press any key to return to the main menu...");
        }

        private static bool ShowAllUsers()
        {
            if (Users.Count == 0)
            {
                Console.WriteLine("There no users Press any key to return to the main menu...");
                return false;
            }
            Console.WriteLine("Here are all the Users:");
            for (int i = 0; i < Users.Count; i++)
            {
                var user = Users[i];
                Console.WriteLine($" {i}: {user.FirstName} {user.LastName}");
            }
            Console.WriteLine("Press any key to return to the main menu...");
            return true;
            
        }


        private static void RemoveUser()
        {
            if (!ShowAllUsers())
            {
                return;
            } 
            
            Console.WriteLine("Pick a user you want to delete");
            string input = Console.ReadLine();
            int removeUser;
            while (!int.TryParse(input, out removeUser))
            {
                Console.WriteLine("Please enter a valid number:");
                input = Console.ReadLine();
            }
            if (removeUser >= 0 && removeUser < Users.Count)
            {
                Users.RemoveAt(removeUser);
                Console.WriteLine("User removed successfully!");
            }
            else
            {
                Console.WriteLine("Invalid user index!");
            }
            Console.WriteLine("Press any key to return to the main menu...");
        }
    }
}