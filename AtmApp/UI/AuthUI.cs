using AtmApp.Models;
using AtmApp.Services;

namespace AtmApp.UI;

// რეგისტრაციის და ლოგინის ეკრანები
public class AuthUI
{
    private UserService userService;

    public AuthUI(UserService userService)
    {
        this.userService = userService;
    }

    public void Register()
    {
        // სამივე ველს ვთხოულობ
        Console.Write("Enter username: ");
        string? username = Console.ReadLine();
        Console.Write("Enter password: ");
        string? password = Console.ReadLine();
        Console.Write("Enter role (client/admin): ");
        string? role = Console.ReadLine();

        // თუ რომელიმე ცარიელია რეგისტრაციას არ ვაკეთებ
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
        {
            Console.WriteLine("All fields are required");
            return;
        }

        // ToLower იმიტომ რომ Admin ან ADMIN რომ დაწეროს მაინც admin-ად ჩაითვალოს
        bool registered = userService.Register(username, password, role.ToLower());
        Console.WriteLine(registered ? "Registration successful" : "Username already exists");
    }

    // აბრუნებს შესულ მომხმარებელს ან null-ს
    public User? Login()
    {
        Console.Write("Enter username: ");
        string? username = Console.ReadLine();
        Console.Write("Enter password: ");
        string? password = Console.ReadLine();

        // ?? ნიშნავს რომ თუ null-ია ცარიელ სტრინგს ჩავსვამ
        User? user = userService.Login(username ?? "", password ?? "");

        if (user == null)
        {
            Console.WriteLine("Invalid username or password");
        }

        return user;
    }
}
