using System.Text.Json;
namespace MenuApp
{
    class Program
    {
        public record User(int Id, string FirstName, string LastName);

        private static List<User> Users = new List<User>();

        static void Main(string[] args)
        {
            LoadUsersFromJson("users.json");
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
            int newId = Users.Count > 0 ? Users.Max(u => u.Id) + 1 : 1;
            Users.Add(new User(newId, firstName, lastName));
            SaveUsersToJson("users.json");
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
                Console.WriteLine($"ID: {Users[i].Id}, First Name: {Users[i].FirstName}, Last Name: {Users[i].LastName}");
            }
            Console.WriteLine("Press any key to return to the main menu...");
            return true;
            
        }
    

        private static void SaveUsersToJson(string filePath)
        {
            var jsonString = JsonSerializer.Serialize(Users);
            File.WriteAllText(filePath, jsonString);
        }

        private static void LoadUsersFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                var jsonString = File.ReadAllText(filePath);
                Users = JsonSerializer.Deserialize<List<User>>(jsonString) ?? new List<User>();
            }
        }

        private static void RemoveUser()
        {
            if (ShowAllUsers() == false)
            {
                return;
            }
            Console.Write("Enter the ID of the user to remove: ");
            if (int.TryParse(Console.ReadLine(), out int userId))
            {
                var userToRemove = Users.FirstOrDefault(u => u.Id == userId);
                if (userToRemove != null)
                {
                    Users.Remove(userToRemove);
                    SaveUsersToJson("users.json");
                    Console.WriteLine("User removed successfully!");
                }
                else
                {
                    Console.WriteLine("User not found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format!");
            }
            Console.WriteLine("Press any key to return to the main menu...");
        }
    }
}