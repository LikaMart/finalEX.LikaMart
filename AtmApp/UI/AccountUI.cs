using AtmApp.Extensions;
using AtmApp.Models;
using AtmApp.Services;

namespace AtmApp.UI;

public class AccountUI
{
    private UserService userService;

    public AccountUI(UserService userService)
    {
        this.userService = userService;
    }

    public void CheckBalance(User user)
    {
        Console.WriteLine($"Balance: {user.Balance}");
    }

    public void Deposit(User user)
    {
        Console.Write("Enter amount: ");
        string? input = Console.ReadLine();

        if (input != null && input.IsValidAmount(out double amount))
        {
            userService.Deposit(user, amount);
            Console.WriteLine("Deposit successful");
        }
        else
        {
            Console.WriteLine("Invalid amount");
        }
    }

    public void Withdraw(User user)
    {
        Console.Write("Enter amount: ");
        string? input = Console.ReadLine();

        if (input != null && input.IsValidAmount(out double amount))
        {
            bool success = userService.Withdraw(user, amount);
            Console.WriteLine(success ? "Withdrawal successful" : "Insufficient balance");
        }
        else
        {
            Console.WriteLine("Invalid amount");
        }
    }
}
