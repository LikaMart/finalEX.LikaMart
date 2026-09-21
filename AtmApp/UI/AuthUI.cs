using AtmApp.Models;
using AtmApp.Services;

namespace AtmApp.UI;

public class AuthUI
{
    private UserService userService;

    public AuthUI(UserService userService)
    {
        this.userService = userService;
    }

    public void Register()
    {
        Console.Write("Enter username: ");
        string? username = Console.ReadLine();
        Console.Write("Enter password: ");
        string? password = Console.ReadLine();
        Console.Write("Enter role (client/admin): ");
        string? role = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
        {
            Console.WriteLine("All fields are required");
            return;
        }

        bool registered = userService.Register(username, password, role.ToLower());
        Console.WriteLine(registered ? "Registration successful" : "Username already exists");
    }

    public User? Login()
    {
        Console.Write("Enter username: ");
        string? username = Console.ReadLine();
        Console.Write("Enter password: ");
        string? password = Console.ReadLine();

        User? user = userService.Login(username ?? "", password ?? "");

        if (user == null)
        {
            Console.WriteLine("Invalid username or password");
        }

        return user;
    }
}
