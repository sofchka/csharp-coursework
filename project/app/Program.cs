using app.DB;
using app.Models;
using app.Services;

namespace app;

class Program
{
    private static UserService _userService = null!;

    static void Main()
    {
        Console.Title = "User Management System";

        var database = new Database();
        database.Initialize();

        _userService = new UserService(database);

        Run();
    }

    static void Run()
    {
        while (true)
        {
            ShowHeader();
            ShowMenu();

            Console.Write("  Select an option: ");
            string choice = Console.ReadLine() ?? "";

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Register();
                    break;

                case "2":
                    Login();
                    break;

                case "3":
                    ChangePassword();
                    break;

                case "4":
                    PrintUsers();
                    break;

                case "5":
                    PrintFriendList();
                    break;

                case "6":
                    RequestFriend();
                    break;

                case "0":
                    Console.WriteLine("  Goodbye!");
                    return;

                default:
                    Error("Invalid option.");
                    break;
            }

            Pause();
        }
    }

    // =========================
    // UI
    // =========================

    static void ShowHeader()
    {
        Console.Clear();

        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║        USER MANAGEMENT SYSTEM        ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.WriteLine();
    }

    static void ShowMenu()
    {
        Console.WriteLine("  ┌────────────────────────────────┐");
        Console.WriteLine("  │            MENU                │");
        Console.WriteLine("  ├────────────────────────────────┤");
        Console.WriteLine("  │  [1] Register                  │");
        Console.WriteLine("  │  [2] Login                     │");
        Console.WriteLine("  │  [3] Change Password           │");
        Console.WriteLine("  │  [4] Print Users               │");
        Console.WriteLine("  │  [5] Print Friend List         │");
        Console.WriteLine("  │  [6] Request a Friend          │");
        Console.WriteLine("  │  [0] Exit                      │");
        Console.WriteLine("  └────────────────────────────────┘");
        Console.WriteLine();
    }

    // =========================
    // Register
    // =========================

    static void Register()
    {
        Section("REGISTER");

        string name = ReadRequired("First name");
        string surname = ReadRequired("Surname");
        string email = ReadRequired("Email");
        string password = ReadPassword("Password");

        bool success = _userService.Register(
            name,
            surname,
            email,
            password);

        Console.WriteLine();

        if (success)
            Success("Account created successfully!");
        else
            Error("An account with this email already exists.");
    }

    // =========================
    // Login
    // =========================

    static void Login()
    {
        Section("LOGIN");

        string email = ReadRequired("Email");
        string password = ReadPassword("Password");

        User? user = _userService.Login(email, password);

        Console.WriteLine();

        if (user == null)
        {
            Error("Invalid email or password.");
            return;
        }

        Success("Login successful!");

        Console.WriteLine();
        Console.WriteLine($"  Welcome, {user.FullName}!");
        Console.WriteLine($"  Email:    {user.Email}");
        Console.WriteLine($"  User ID:  {user.UserId}");
    }

    // =========================
    // Change Password
    // =========================

    static void ChangePassword()
    {
        Section("CHANGE PASSWORD");

        string email = ReadRequired("Email");
        string currentPassword = ReadPassword("Current password");

        User? user = _userService.Login(email, currentPassword);

        if (user == null)
        {
            Console.WriteLine();
            Error("Invalid email or current password.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"  Hello, {user.FullName}!");

        string newPassword = ReadPassword("New password");
        string confirmPassword = ReadPassword("Confirm password");

        if (newPassword != confirmPassword)
        {
            Console.WriteLine();
            Error("Passwords do not match.");
            return;
        }

        bool success = _userService.ChangePassword(
            user.UserId,
            currentPassword,
            newPassword);

        Console.WriteLine();

        if (success)
            Success("Password changed successfully!");
        else
            Error("Password was not changed.");
    }

    // =========================
    // Print Users
    // =========================

    static void PrintUsers()
    {
        Section("USERS");

        int page = ReadPositiveInteger("Page");
        int pageSize = ReadPositiveInteger("Users per page");

        List<User> users = _userService.GetUsers(page, pageSize);

        if (users.Count == 0)
        {
            Error("No users found.");
            return;
        }

        Console.WriteLine();

        foreach (User user in users)
        {
            Console.WriteLine($"  ID: {user.UserId}");
            Console.WriteLine($"  Name: {user.FullName}");
            Console.WriteLine($"  Email: {user.Email}");
            Console.WriteLine("  ------------------------------");
        }
    }

    // =========================
    // Print Friend List
    // =========================

    static void PrintFriendList()
    {
        Section("FRIEND LIST");

        int userId = ReadPositiveInteger("User ID");

        List<User> friends = _userService.GetFriends(userId);

        Console.WriteLine();

        if (friends.Count == 0)
        {
            Console.WriteLine("  No friends found.");
            return;
        }

        foreach (User friend in friends)
        {
            Console.WriteLine($"  ID: {friend.UserId}");
            Console.WriteLine($"  Name: {friend.FullName}");
            Console.WriteLine($"  Email: {friend.Email}");
            Console.WriteLine("  ------------------------------");
        }
    }

    // =========================
    // Request Friend
    // =========================

    static void RequestFriend()
    {
        Section("REQUEST A FRIEND");

        int userId = ReadPositiveInteger("Your User ID");
        int friendId = ReadPositiveInteger("Friend User ID");

        bool success = _userService.RequestFriend(
            userId,
            friendId);

        Console.WriteLine();

        if (success)
            Success("Friend request created successfully!");
        else
            Error("Could not create friend request.");
    }

    // =========================
    // Input helpers
    // =========================

    static string ReadRequired(string label)
    {
        while (true)
        {
            Console.Write($"  {label}: ");
            string value = Console.ReadLine()?.Trim() ?? "";

            if (!string.IsNullOrWhiteSpace(value))
                return value;

            Error("This field cannot be empty.");
        }
    }

    static string ReadPassword(string label)
    {
        Console.Write($"  {label}: ");

        string password = "";

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
                break;

            if (key.Key == ConsoleKey.Backspace)
            {
                if (password.Length > 0)
                {
                    password = password[..^1];
                    Console.Write("\b \b");
                }

                continue;
            }

            if (!char.IsControl(key.KeyChar))
            {
                password += key.KeyChar;
                Console.Write("*");
            }
        }

        Console.WriteLine();

        return password;
    }

    static int ReadPositiveInteger(string label)
    {
        while (true)
        {
            Console.Write($"  {label}: ");
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int value) && value > 0)
                return value;

            Error("Please enter a positive number.");
        }
    }

    // =========================
    // UI helpers
    // =========================

    static void Section(string title)
    {
        Console.WriteLine("┌──────────────────────────────────────┐");
        Console.WriteLine($"│  {title,-35}│");
        Console.WriteLine("└──────────────────────────────────────┘");
        Console.WriteLine();
    }

    static void Success(string message)
    {
        Console.WriteLine($"  ✓ {message}");
    }

    static void Error(string message)
    {
        Console.WriteLine($"  ✗ {message}");
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.Write("  Press ENTER to continue...");
        Console.ReadLine();
    }
}